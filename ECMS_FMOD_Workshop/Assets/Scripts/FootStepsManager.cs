using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio; 
 

public class FootStepsManager : MonoBehaviour
{   [SerializeField] private EventReference footStepsReference;
    [SerializeField] private EventReference jumpStartRef;
    [SerializeField] private EventReference jumpLandRef;
    [SerializeField] private PhysicsPM_MatDetector physicsPM_MatDetector;
    EventInstance footStep;
    
    public void FootStepDown()
    {
        footStep = RuntimeManager.CreateInstance(footStepsReference);
        footStep.setParameterByName("Terrain", physicsPM_MatDetector.matIdx);//matIdx is from PhysicsPM_MatDetector script  
        //footStep.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        footStep.start();
        footStep.release();

     /*   if (Input.GetButton("Run"))
        {
            footStep.setParameterByName("LocomotionType", 1);
        }
        else
        footStep.setParameterByName("LocomotionType", 0);*/
    }
    
    public void Jump()
    {
        
        RuntimeManager.PlayOneShot(jumpStartRef, transform.position);
    }

    public void JumpLand()
    {
        RuntimeManager.PlayOneShot(jumpLandRef, transform.position);
    }
}
