using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    void Start() {
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
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //spawn enemy death explosion FX at enemy location
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
