using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(gameObject);   
    }

    void Start()
    {
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad() 
    {
        yield return new WaitForSeconds (3f);
        SceneManager.LoadScene(1);
    }
}
