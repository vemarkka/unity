using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
  public float speed= 35.0f;

    public bool hasPowerup=false;
    public bool hasEnemy = false;
    public ParticleSystem explosionParticle;
    public GameObject powerupIndicator;
    public GameObject enemyIndicator;
    public AudioClip takeGas;
    private AudioSource playerAudio;
private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    private GameManager gameManager;
    private Target targetManager;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



    }

    // Update is called once per frame
    void Update()
    {
        UpdateDrive();

    }
  public void UpdateDrive()
    {
        if (gameManager.isGameActive)
        {

            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
            enemyIndicator.transform.position = transform.position + new Vector3(0, -10f, 0);
        }
    }
    public void OnTriggerEnter (Collider other)
    {

        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(takeGas, 2.0f);
            gameManager.UpdateScore(1);


        }


        if (other.gameObject.CompareTag("Enemy"))
        {
            hasEnemy = true;
            enemyIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);


        }
    }
