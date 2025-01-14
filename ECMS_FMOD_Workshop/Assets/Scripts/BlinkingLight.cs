using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Interval between blinks in seconds
    public Light lightSource; // Reference to the light component

    private float timer; // Timer to keep track of time
    float minBlink = 0.5f;
    float maxBlink = 0.03f;

    
    void Start()
    {
        // Initialize timer
        timer = 0f;
        StartCoroutine(BlinkLight());
        
    }


    IEnumerator BlinkLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f)); // Change the range as needed
            blinkInterval = Random.Range(minBlink, maxBlink + 0.1f);
        }
    }

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to blink
        if (timer >= blinkInterval)
        {
            // Toggle the light on/off
            lightSource.enabled = !lightSource.enabled;

            // Reset the timer
            timer = 0f;
        }
    }


}

