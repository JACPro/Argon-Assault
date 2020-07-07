using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In (m/s)^-1")][SerializeField] float xSpeed = 4f;

    void Start()
    {
        
    }

    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -3, 3);
        
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
    }
}
