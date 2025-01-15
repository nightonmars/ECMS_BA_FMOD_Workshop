using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class FMOD_GateSounds : MonoBehaviour
{
    [SerializeField] private EventReference gateSoundSequenceReference;
    private EventInstance gateSoundSequence;
    
    
    public void PlayGateSequenceSound()
    {
        gateSoundSequence = RuntimeManager.CreateInstance(gateSoundSequenceReference);
        gateSoundSequence.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
        gateSoundSequence.start();
    }

    public void GateSequenceSetGateParam()
    {
        gateSoundSequence.setParameterByName("GateSequenceParam", 1); 
    }

    public void StopGateSequenceSound()
    {
        gateSoundSequence.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        gateSoundSequence.release();
    }
    
 
}
