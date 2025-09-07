using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UIControls : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private Canvas pauseMenuCanvas;
    [SerializeField] private InputActionAsset actionAsset;

    private ColorAdjustments colorAdjustments;
    private bool isPaused = false;

    private InputAction toggleCanvasAction;

    private void Start()
    {
        // Get the color adjustments from the volume profile
        if (volume.profile.TryGet(out ColorAdjustments adjustments))
        {
            colorAdjustments = adjustments;
        }
        else
        {
            Debug.LogError("ColorAdjustments not found in Volume Profile.");
        }

        // Ensure the canvas is hidden at the start
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.enabled = false;

        // Find the action named "UIControl" in the asset
        toggleCanvasAction = actionAsset.FindAction("UIControl");

        if (toggleCanvasAction != null)
        {
            toggleCanvasAction.performed += ToggleCanvas;
            toggleCanvasAction.Enable();
        }
        else
        {
            Debug.LogError("Input Action 'UIControl' not found in InputActionAsset.");
        }
    }

    private void OnDisable()
    {
        if (toggleCanvasAction != null)
        {
            toggleCanvasAction.performed -= ToggleCanvas;
        }
    }

    private void ToggleCanvas(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (pauseMenuCanvas != null)
            pauseMenuCanvas.enabled = isPaused;

        Time.timeScale = isPaused ? 0 : 1; // Pause/unpause game

        // Show/hide cursor
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;

        Debug.Log("Pause Menu Toggled: " + isPaused);
    }

    public void AdjustBrightness(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
            Debug.Log("Adjusting Brightness " + value);
        }
    }

    public void AdjustContrast(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.contrast.value = value;
        }
    }
}
