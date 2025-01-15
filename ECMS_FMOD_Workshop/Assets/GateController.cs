using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GateController : MonoBehaviour
{
    [SerializeField] private Animator barAnimator; 
    [SerializeField] private Animator[] gateAnimators; // Array to hold multiple animators
    [SerializeField] private float gateDelayTime = 2.0f;
    [SerializeField] private UnityEvent startBarSound; // Public float for delay time
    [SerializeField] private UnityEvent startGateSound;
    [SerializeField] private bool openGate = true;
    

    private string barTrigger = "BarTrigger";
    private string gateTrigger = "GateOpen";
    [ContextMenu("Open Gate")]
    // Function to start the bar and gate sequence
    public void StartBarAndGateSequence()
    {
        if (openGate)
        {
            StartCoroutine(BarAndGateSequence());
            openGate = false;
        }
    }

    private IEnumerator BarAndGateSequence()
    {
        // Trigger the bar animation
        barAnimator.SetTrigger(barTrigger);
        startBarSound.Invoke();

        // Wait for the specified delay time
        yield return new WaitForSeconds(gateDelayTime);
        startGateSound.Invoke();
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