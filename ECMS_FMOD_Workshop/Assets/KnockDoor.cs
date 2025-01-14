using UnityEngine;

using FMODUnity;
using FMOD.Studio;

public class KnockDoor : MonoBehaviour
{

    EventInstance knockOnDoor;

  
    void Update()
    {
        // Check if the "e" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            Knock();
        }
    }


    private void Knock()
    {
        
        knockOnDoor = RuntimeManager.CreateInstance("event:/KnockTheDoor");
        knockOnDoor.start();
        knockOnDoor.release();;
        Debug.Log("knock"); 
    }
}
