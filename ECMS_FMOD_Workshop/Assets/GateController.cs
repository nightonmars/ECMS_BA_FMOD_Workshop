using System.Collections;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private Animator barAnimator; 
    [SerializeField] private Animator[] gateAnimators; // Array to hold multiple animators
    [SerializeField] private float gateDelayTime = 2.0f; // Public float for delay time

    private string barTrigger = "BarTrigger";
    private string gateTrigger = "GateOpen";
    [ContextMenu("Open Gate")]
    // Function to start the bar and gate sequence
    public void StartBarAndGateSequence()
    {
        StartCoroutine(BarAndGateSequence());
    }

    private IEnumerator BarAndGateSequence()
    {
        // Trigger the bar animation
        barAnimator.SetTrigger(barTrigger);

        // Wait for the specified delay time
        yield return new WaitForSeconds(gateDelayTime);

        // Trigger the gate animations
        foreach (Animator animator in gateAnimators)
        {
            if (animator != null) // Ensure the animator exists
            {
                animator.SetBool(gateTrigger, true);
            }
        }
    }
}