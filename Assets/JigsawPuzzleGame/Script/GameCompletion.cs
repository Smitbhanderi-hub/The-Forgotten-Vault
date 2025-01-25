using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompletion : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Array of all puzzle pieces

    // Method to check if the puzzle is complete
    public void CheckCompletion()
    {
        int lockedCount = 0; // Counter for correctly locked pieces

        // Loop through each puzzle piece
        foreach (GameObject piece in puzzlePieces)
        {
            DragAndDrop dragScript = piece.GetComponent<DragAndDrop>();

            // Ensure the piece is both locked and correctly placed
            if (dragScript != null && dragScript.IsCorrectAndLocked())
            {
                lockedCount++;
            }
        }

        // If all pieces are locked and correctly placed
        if (lockedCount == puzzlePieces.Length)
        {
            OnGameComplete();
        }
    }

    // Triggered when the game is completed
    private void OnGameComplete()
    {
        Debug.Log("Puzzle Completed!");

        // Stop the timer
        FindObjectOfType<GameTimer>().StopTimer();

        // Load the next scene (e.g., Ending Screen)
        SceneManager.LoadScene("EndingScreen1"); // Replace with your scene name
    }
}