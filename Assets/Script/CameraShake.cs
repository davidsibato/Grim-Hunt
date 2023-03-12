using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    private float shakeTimeRemaining = 1f;
    private bool isCameraShaking = false;
    private float shakeMagnitude = 2f;


    void Update()
    {
        if (isCameraShaking)
        {
            if (shakeTimeRemaining > 0)
            {
                // Generate a random offset to apply to the camera position
                Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;

                // Apply the shake offset to the camera position
                transform.localPosition = shakeOffset;

                // Decrease the shake time remaining
                shakeTimeRemaining -= Time.deltaTime;
            }
            else
            {
                // Reset the camera position
                transform.localPosition = Vector3.zero;

                isCameraShaking = false;
            }
        }
    }

    // Start shaking the screen for the specified duration and magnitude
    //public void Shake(float duration, float magnitude)
    //{
    //    shakeTimeRemaining = duration;
    //    shakeMagnitude = magnitude;
    //}

    public void shaking()
    {
        isCameraShaking=true;
    }
}