using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleTapToSkip : MonoBehaviour
{
    public string nextSceneName; // Name of the scene to load after skipping
    public float maxTapInterval = 0.5f; // Max time (in seconds) between two taps to register as double-tap

    private float lastTapTime = 0f; // Time of the last tap

    void Update()
    {
        // Check if the user taps the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            float currentTime = Time.time;

            // Check if the time between the last tap and this tap is within the max interval
            if (currentTime - lastTapTime <= maxTapInterval)
            {
                Debug.Log("Double-tap detected. Skipping intro...");
                SkipIntro();
            }

            // Update the last tap time
            lastTapTime = currentTime;
        }

        // Optional: Support double-click for mouse (for testing in the editor)
        if (Input.GetMouseButtonDown(0))
        {
            float currentTime = Time.time;

            if (currentTime - lastTapTime <= maxTapInterval)
            {
                Debug.Log("Double-click detected. Skipping intro...");
                SkipIntro();
            }

            lastTapTime = currentTime;
        }
    }

    // Method to skip the intro and load the next scene
    private void SkipIntro()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}