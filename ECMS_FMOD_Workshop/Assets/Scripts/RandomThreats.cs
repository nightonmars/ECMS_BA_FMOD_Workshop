using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class RandomThreats : MonoBehaviour
{
    [SerializeField] private EventReference randomThreatEventReference;
    [SerializeField] private DistanceTracker distanceTracker;
    public int randomThreat;
    public int randomThreatValue;
    public int minThreat = 0;
    public int maxThreat = 100;
    public float minInterval = 1f;
    public float maxInterval = 10f;

    private void Start()
    {
        //StartCoroutine(RandomThreatCoroutine());
        StartCoroutine(RandomTriggerCoroutine());
    }
    /*
    IEnumerator RandomThreatCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f)); // Change the range as needed
            randomThreatValue = Random.Range(minThreat, maxThreat + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        randomThreat = (int)distanceTracker.totalDistance;
        if (randomThreat == randomThreatValue || randomThreat == 2 || randomThreat == 20 || randomThreat == 25 || randomThreat == 30)
        {
            Debug.Log("scary sound");
            randomThreatValue = Random.Range(minThreat, maxThreat + 1);
            RuntimeManager.PlayOneShot("event:/RandomThreats");
        }

    }

    

   */

    IEnumerator RandomTriggerCoroutine()
    {
        while (true)
        {
            // Generate a random time interval between minInterval and maxInterval
            float interval = Random.Range(minInterval, maxInterval);

            // Wait for the random interval
            yield return new WaitForSeconds(interval);

            // Trigger your method here
            RandomThreatsPlay();
        }
    }

    void RandomThreatsPlay()
    {
       
        RuntimeManager.PlayOneShot(randomThreatEventReference);
    }
}
