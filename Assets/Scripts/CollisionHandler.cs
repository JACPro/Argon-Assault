using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    Timer timer;

    void Start() 
    {
        timer = FindObjectOfType<Timer>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    void StartDeathSequence() 
    {
        print("Player died!");
        timer.StopTimer();
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
