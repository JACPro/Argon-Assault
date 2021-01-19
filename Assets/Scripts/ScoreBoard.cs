using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    public void ScoreHit(int scoreToAdd) 
    {
        score += scoreToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE:   " + score;
    }
}