using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{


    private float repeatRate = 1.0f;
    private PlayerController playerControllerScript;
    private float minDistance = 10.0f;
    private float maxDistance = 25.0f;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public GameObject titleScreen;
    public Button restartButton;
    public Button startButton;

    public float timeLeft = 60.0f;


    public List<GameObject> target;



    public bool isGameActive;
    private int score;
    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update

     void Start()
    {


    }
   public void StartGame()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();


        isGameActive = true;
        score = 0;
        timeLeft = 60;

        StartCoroutine(SpawnTarget());

        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);


    }
    // Update is called once per frame
    private void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.SetText("Time:" + Mathf.Round(timeLeft));
            if (timeLeft < 0)
            {
                GameOver();


            }
        }






    }



    Vector3 GenerateSpawnPosition()
    {
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        Vector3 spawnPosition = playerControllerScript.transform.position;
        spawnPosition += new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, - 300, 300);
        spawnPosition.y = -10.0f;
        spawnPosition.z = Mathf.Clamp(spawnPosition.z, -300, 300);




        return spawnPosition;

    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(repeatRate);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index], GenerateSpawnPosition(), target[index].transform.rotation);


        }
    }


    public void UpdateScore(int scoreToAdd)
        {
            isGameActive = true;
            score += scoreToAdd;

            scoreText.text = "Gas:" + score;
        }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        StopAllCoroutines();


    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }







}
