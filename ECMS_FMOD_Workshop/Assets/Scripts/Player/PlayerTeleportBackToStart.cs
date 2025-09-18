using UnityEngine;

public class PlayerTeleportBackToStart : MonoBehaviour
{
   
    [SerializeField] Transform playerCapsule;
    [SerializeField] Transform teleportPosEnd;
    private CharacterController characterController;
    private bool isTeleporting = true;

    void Start()
    {
        characterController = playerCapsule.GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isTeleporting)
        {
            characterController.enabled = false;
            isTeleporting = false; 
            playerCapsule.position = teleportPosEnd.position;
            characterController.enabled = true;
            isTeleporting = true; 
            
        }
    }
}
