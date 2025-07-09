using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class FMOD_GateTrigger : MonoBehaviour
{
    // Define a tag to identify the player or triggering object
    private string triggeringTag = "Player";
    
    [SerializeField] private UnityEvent openGateEvent;
    [SerializeField] private float openGateTime;

    [SerializeField] private PlayFMODSound playFMODSound;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the specified tag
        if (other.CompareTag(triggeringTag))
        {
            // Play the FMOD sound event
            playFMODSound.PlayOneShot();
            

            // Start the coroutine for delayed action
            StartCoroutine(DelayedAction(openGateTime));
        }
    }

    private IEnumerator DelayedAction(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);
        openGateEvent.Invoke();
    }
}