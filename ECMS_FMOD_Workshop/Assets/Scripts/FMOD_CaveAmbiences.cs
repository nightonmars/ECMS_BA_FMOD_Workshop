using UnityEngine;

public class FMOD_CaveAmbiences : MonoBehaviour
{
    [SerializeField] private DistanceTracker distanceTracker;
    [SerializeField] private PlayFMODMultipleSounds fmodMultipleSounds;
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
        fmodMultipleSounds.SetParameter(2,"Tracker", movingAmbienceTrigger );
    }

    public void PlayAmbience()
    {
        fmodMultipleSounds.PlaySound(1);
    }

    public void PlayMovingAmbience()
    {
        fmodMultipleSounds.PlaySound(2);
    }
}
