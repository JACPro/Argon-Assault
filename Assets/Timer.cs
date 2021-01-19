using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    bool timerActive;
    bool playerAlive;

    ScoreBoard scoreBoard;

    [SerializeField] int scoreToAdd = 10;
    [SerializeField] int timeUntilAddScore = 5;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        playerAlive = true; 
        timerActive = false;
        StartCoroutine(WaitToAddScore());
    }

    public void StopTimer()
    {
        playerAlive = false;
    }    
    
    void Update()
    {
        if (playerAlive && timerActive)
        {
            timerActive = false;
            scoreBoard.ScoreHit(scoreToAdd);
            StartCoroutine(WaitToAddScore());
        }
    }

    IEnumerator WaitToAddScore()
    {
        yield return new WaitForSeconds(timeUntilAddScore);
        timerActive = true;
    }
}
