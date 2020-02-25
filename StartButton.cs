using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartButton : MonoBehaviour

{
    public Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(StartDrive);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartDrive()
    {
        gameManager.StartGame();

    }


}
