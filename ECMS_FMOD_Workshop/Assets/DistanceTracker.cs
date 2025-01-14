using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using FMODUnity;
using FMOD.Studio;

public class DistanceTracker : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 lastPosition;
    public float totalDistance;
    public float loopValue = 50f;
    EventInstance music; 

    void Start()
    {
        // Assuming your player GameObject has a CharacterController component attached
        characterController = GetComponent<CharacterController>();

        // Initialize the last position to the initial position of the player
        lastPosition = characterController.transform.position;
        music = RuntimeManager.CreateInstance("event:/Music");
        music.start(); 
    }

    void Update()
    {
        // Calculate the distance traveled since the last frame
        float distanceThisFrame = Vector3.Distance(characterController.transform.position, lastPosition);

        // Update the total distance traveled
        totalDistance += distanceThisFrame;
     
  
        music.setParameterByName("Tracker", totalDistance); 

        // Update the last position to the current position
        lastPosition = characterController.transform.position;
        if(totalDistance > loopValue)
        {
            ResetTotalDistance();
        }
            
    }

    // Function to get the total distance traveled
    public float GetTotalDistance()
    {
        return totalDistance;
    }

    // Function to reset the total distance
    public void ResetTotalDistance()
    {
        totalDistance = 0f;
    }
}
