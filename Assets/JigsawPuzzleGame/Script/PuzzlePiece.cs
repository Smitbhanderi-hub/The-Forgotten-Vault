using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public bool isCorrect = false; // Tracks if the piece is placed correctly

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot")) // Assuming your slots have the "Slot" tag
        {
            // Check if the slot matches this piece
            if (collision.name == gameObject.name)
            {
                isCorrect = true; // Mark as correct
                Debug.Log($"{gameObject.name} is in the correct slot!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot"))
        {
            isCorrect = false; // Reset when the piece is moved away
        }
    }
}