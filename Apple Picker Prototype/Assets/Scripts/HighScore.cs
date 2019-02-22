using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI framework

public class HighScore : MonoBehaviour
{
    public static int score = 1000;

    private void Awake()
    {
        // If the PlayerPrefs HighScore already exists, read it, rememebr that PlayerPrefs stores info on the ocmputer for future use
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //Assign the high score is HighScore Player PRefs and ensures that the highScoe key is created.
        PlayerPrefs.SetInt("HighScore", score);
    }
    // Update is called once per frame
    void Update()
    {
        Text highScore = this.GetComponent<Text>();
        highScore.text = "High SCore: " + score; //ToString called implicity

        //update the PlayerPrefs HighScore if neccessary
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

/* Using PlayerPrefs ensures that the high score to be remembered on this machine even if Unity is shurtdown or restarted. */