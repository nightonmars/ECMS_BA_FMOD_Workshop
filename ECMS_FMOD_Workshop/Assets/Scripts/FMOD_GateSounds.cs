using UnityEngine;

public class FMOD_GateSounds : MonoBehaviour
{
    [SerializeField] private PlayFMODSound playFMODSound;
    
    public void PlayGateSequenceSound()
    {
        playFMODSound.PlaySound(); 
    }

    public void GateSequenceSetGateParam()
    {
        playFMODSound.SetParameter("GateSequenceParam", 1);
    }

    public void StopGateSequenceSound()
    {
        playFMODSound.StopSound(); 
    }
    
 
}
