using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI framework

public class HighScore : MonoBehaviour
{
    public static int score = 1000;

    // Update is called once per frame
    void Update()
    {
        Text highScore = this.GetComponent<Text>();
        highScore.text = "High SCore: " + score;
    }
}
