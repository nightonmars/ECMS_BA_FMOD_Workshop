using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.Events;

public class DistanceTracker : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private UnityEvent OnLooptimeTrigger; 
    private Vector3 lastPosition;
    public float totalDistance;
    public float loopValue = 50f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        lastPosition = characterController.transform.position;
    }

    void Update()
    {
        float distanceThisFrame = Vector3.Distance(characterController.transform.position, lastPosition);
        
        totalDistance += distanceThisFrame;
        
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
    
    public void ResetTotalDistance()
    {
        totalDistance = 0f;
    }
}
