using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio; 
 

public class FootStepsManager : MonoBehaviour
{   public EventReference footStepsEvent;
    public void FootStepDown()
    {
        RuntimeManager.PlayOneShot(footStepsEvent); 
    }
}
