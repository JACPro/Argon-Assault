using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In (m/s)^-1")][SerializeField] float controlSpeed = 5f;
    [Tooltip("In m")] [SerializeField] float xRange = 1f;
    [Tooltip("In m")] [SerializeField] float yRange = 1.2f;
    [SerializeField] GameObject[] guns;
    
    [Header("Sceen-position Based")]
    [SerializeField] float positionPitchFactor = 10f;
    [SerializeField] float positionYawFactor = -5f;
    
    [Header("Controle-throw Based")]    
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;

    bool isControlEnabled = true;

    void Update()
    {
        if (isControlEnabled) {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition  +pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;
        
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }        
    }

    void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(isActive);
        }
    }

    void OnPlayerDeath() //called by string reference
    {
        isControlEnabled = false;
    }
}
