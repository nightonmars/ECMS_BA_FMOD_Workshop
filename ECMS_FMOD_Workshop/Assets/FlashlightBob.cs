using UnityEngine;

public class FlashlightBob : MonoBehaviour
{
    public float bobFrequency = 1.5f; // How fast the bobbing occurs
    public float bobAmplitude = 0.05f; // How high/low the flashlight moves
    public Transform characterTransform; // Reference to the character's transform
    public float movementThreshold = 0.1f; // Minimum speed to start bobbing

    private Vector3 initialPosition;
    private float timer = 0f;

    void Start()
    {
        // Save the initial position of the flashlight
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (characterTransform == null)
        {
            Debug.LogWarning("Character Transform not assigned!");
            return;
        }

        // Check the character's speed
        float speed = characterTransform.GetComponent<CharacterController>().velocity.magnitude;

        if (speed > movementThreshold)
        {
            // Increment the timer based on speed
            timer += Time.deltaTime * bobFrequency;

            // Calculate the bobbing motion
            float verticalOffset = Mathf.Sin(timer) * bobAmplitude;
            float horizontalOffset = Mathf.Cos(timer * 0.5f) * bobAmplitude * 0.5f;

            // Apply the offsets to the flashlight's position
            transform.localPosition = initialPosition + new Vector3(horizontalOffset, verticalOffset, 0f);
        }
        else
        {
            // Reset the timer and position when not moving
            timer = 0f;
            transform.localPosition = initialPosition;
        }
    }
}