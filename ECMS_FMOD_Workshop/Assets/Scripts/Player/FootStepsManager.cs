using UnityEngine;
using FMOD.Studio; 
 

public class FootStepsManager : MonoBehaviour
{   
    [SerializeField] private PlayFMODMultipleSounds fmodMultipleSounds;
    [SerializeField] private PhysicsPM_MatDetector physicsPM_MatDetector;
    EventInstance footStep;
    
    public void FootStepDown()
    {
        fmodMultipleSounds.PlaySound(0);
        fmodMultipleSounds.SetParameter(0, "Terrain", physicsPM_MatDetector.matIdx);
    }
    
    public void Jump()
    {
        fmodMultipleSounds.PlayOneShotWithParam(1);
        fmodMultipleSounds.SetParameter(1, "Terrain", physicsPM_MatDetector.matIdx);
    }

    public void JumpLand()
    {
        fmodMultipleSounds.PlayOneShotWithParam(2);
        fmodMultipleSounds.SetParameter(2, "Terrain", physicsPM_MatDetector.matIdx);
    }
}
/*   if (Input.GetButton("Run"))
      {
          footStep.setParameterByName("LocomotionType", 1);
      }
      else
      footStep.setParameterByName("LocomotionType", 0);*/