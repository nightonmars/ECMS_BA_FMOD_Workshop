using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private Animator flashlightAnimator;

    // Key to toggle the flashlight
    [SerializeField] private KeyCode toggleKey = KeyCode.F;
    [SerializeField] private float lightIntensity = 52;

    // Flag to track flashlight state
    private bool isFlashlightOn = false;

    // Light intensity lerp speed
    [SerializeField] private float lerpSpeed = 2.0f;

    private void Start()
    {
        flashlight.intensity = 0f;
        isFlashlightOn = false; 
    }

    void Update()
    {
        // Check if the toggle key is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleFlashlight();
        }
    }

    private void ToggleFlashlight()
    {
        // Toggle the flashlight state
        isFlashlightOn = !isFlashlightOn;

        // Start the coroutine to lerp the light intensity
        if (flashlight != null)
        {
            StopAllCoroutines(); // Stop any ongoing lerp
            StartCoroutine(LerpLightIntensity(isFlashlightOn ? lightIntensity : 0.0f));
        }

        // Play the toggle animation if animator is set
        if (flashlightAnimator != null)
        {
            flashlightAnimator.SetBool("FlashLight", isFlashlightOn);
        }
    }

    private IEnumerator LerpLightIntensity(float targetIntensity)
    {
        float startIntensity = flashlight.intensity;
        float elapsedTime = 0f;

        while (elapsedTime < 1f / lerpSpeed)
        {
            elapsedTime += Time.deltaTime;
            flashlight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime * lerpSpeed);
            yield return null;
        }

        flashlight.intensity = targetIntensity;
    }
}