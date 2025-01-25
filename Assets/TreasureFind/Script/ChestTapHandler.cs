using UnityEngine;
using UnityEngine.SceneManagement; // To load the next scene or end the game

public class ChestTapHandler : MonoBehaviour
{
    private bool isChestFound = false; // To track if the chest is found

    void OnMouseDown()
    {
        // Check if the chest is found
        if (isChestFound)
        {
            // Trigger game finish actions, like showing a "You win!" message or loading a new scene
            FinishGame();
        }
    }

    // You can call this method when the chest is found
    public void MarkChestAsFound()
    {
        isChestFound = true;
    }

    void FinishGame()
    {
        // Example: Load a "Game Over" scene or a "You Win!" screen
        Debug.Log("Game Finished!"); // You can replace this with your custom finish logic
        // Uncomment below line if you want to load a different scene
        // SceneManager.LoadScene("GameOverScene");
    }
}