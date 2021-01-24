using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int hits = 10;

    ScoreBoard scoreBoard;
    [SerializeField] int scoreValue = 300;

    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddBoxCollider();
    }

    /*
    Box collider added at runtime so that if the asset pack is updated and components we've added 
    are removed, we won't run into hit detection issues.
    NOTE: No trigger on added box collider
    */
    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false; 
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (hits <= 0)
        {
            Die();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scoreValue);
        hits--;
        //Consider hit FX
    }

    private void Die()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //spawn enemy death explosion FX at enemy location
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
