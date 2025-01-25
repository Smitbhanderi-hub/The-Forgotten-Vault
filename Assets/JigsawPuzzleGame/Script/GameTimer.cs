using UnityEngine;
using UnityEngine.UI; // For UI Text
using TMPro; // If using TextMeshPro

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // If using TextMeshPro
    // public Text timerText; // Uncomment this if using regular Text

    private float elapsedTime = 0f;
    private bool isTimerRunning = true;

    void Start()
    {
        elapsedTime = 0f; // Reset the timer at the start
        UpdateTimerText(); // Initialize the timer text
    }

    void Update()
    {
        if (isTimerRunning)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Update the timer display
            UpdateTimerText();
        }
    }

    // Updates the timer display
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Convert to minutes
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Remaining seconds

        // Update the timer text (format as "MM:SS")
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Stops the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Retrieves the total elapsed time
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}