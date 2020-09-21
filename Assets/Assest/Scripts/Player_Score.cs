using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    private float timeLeft = 200;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;


    void Start()
    {
        //Just for testing
        DataManagement.datamanagement.LoadData();
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int) timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    void OnTriggerEnter2D(Collider2D trig){
        if (trig.gameObject.name == "victory flag")
        {
            CountScore();
        }

        if (trig.gameObject.name == "coin")
        {
            playerScore += 100;
            Destroy(trig.gameObject);
        }


    }

    void CountScore() {
        playerScore = playerScore + (int)(timeLeft * 10);
        DataManagement.datamanagement.highScore = playerScore + (int)(timeLeft * 10);
        DataManagement.datamanagement.SaveData();

    }
}
