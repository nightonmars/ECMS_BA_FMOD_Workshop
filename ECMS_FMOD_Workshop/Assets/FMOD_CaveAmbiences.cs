using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMOD_CaveAmbiences : MonoBehaviour
{
    [SerializeField] private DistanceTracker distanceTracker;
    [SerializeField] private FMODUnity.EventReference ambienceReference;
    [SerializeField] private FMODUnity.EventReference movingAmbienceReference;
    private EventInstance ambienceInstance;
    private EventInstance movingAmbienceInstance;
    public bool playAmbience;
    public bool playMovingAmbience;
    private float movingAmbienceTrigger; 

    private void Start()
    {
        if (playMovingAmbience)
        {
            PlayMovingAmbience();
        }

        if (playAmbience)
        {
            PlayAmbience();
        }
    }

    private void Update()
    {
        movingAmbienceTrigger = distanceTracker.totalDistance;
        movingAmbienceInstance.setParameterByName("Tracker", movingAmbienceTrigger); 
        //Debug.Log("move "+movingAmbienceTrigger);
        float parameterValue;
        movingAmbienceInstance.getParameterByName("Tracker", out parameterValue);
    }

    public void PlayAmbience()
    {
        ambienceInstance = RuntimeManager.CreateInstance(ambienceReference);
        ambienceInstance.start();
    }

    public void PlayMovingAmbience()
    {
        movingAmbienceInstance = RuntimeManager.CreateInstance(movingAmbienceReference);
        movingAmbienceInstance.start(); 
        //movingAmbienceInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

        
            
    }
}
