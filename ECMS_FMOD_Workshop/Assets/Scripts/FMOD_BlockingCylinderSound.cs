using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMOD_BlockingCylinderSound : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private EventReference blockCylSoundReference;
    private FMOD.Studio.EventInstance moveSound;
    

    private Vector3 previousPosition;
    private bool isMoving = false;

    void Start()
    {
        // Initialize the Rigidbody and FMOD event instance
        rb = GetComponent<Rigidbody>();
        moveSound = FMODUnity.RuntimeManager.CreateInstance(blockCylSoundReference);

        // Set the initial position
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate movement by checking position difference
        Vector3 currentPosition = transform.position;
        float distanceMoved = Vector3.Distance(currentPosition, previousPosition);

        // Check if the object is moving
        if (distanceMoved > 0.01f && !isMoving) // Threshold to detect movement
        {
            isMoving = true;
            StartSound();
        }
        else if (distanceMoved <= 0.01f && isMoving)
        {
            isMoving = false;
            StopSound();
        }

        // Update the previous position
        previousPosition = currentPosition;
    }

    void StartSound()
    {
        if (!isMoving)
        {
            moveSound.start();
        }
    }

    void StopSound()
    {
        if (isMoving)
        {
            moveSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void OnDestroy()
    {
        // Release FMOD instance on destroy to free resources
        moveSound.release();
    }
}

