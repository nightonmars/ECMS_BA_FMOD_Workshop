using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPopUp : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        if (canvas != null)
            canvas.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (canvas == null)
            return;

        if (other.CompareTag("Player"))
        {
            canvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

    // Public method to restart the game
    public void Restart()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Optionally disable the popup if you want to close it
        if (canvas != null)
            canvas.enabled = false;

        // Reload current scene
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}