using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] Transform playerCapsule;
    [SerializeField] Transform teleportPosEnd;
    private CharacterController characterController;

    void Start()
    {
        characterController = playerCapsule.GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teleport");
            // Disable CharacterController before teleporting
            characterController.enabled = false;

            // Move the player to the teleport destination
            playerCapsule.position = teleportPosEnd.position;
            

            // Re-enable CharacterController after teleport
            characterController.enabled = true;
        }
    }
}