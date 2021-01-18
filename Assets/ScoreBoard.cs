using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 10;

    int score;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    public void ScoreHit() 
    {
        score += scorePerHit;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE:   " + score;
    }
}