using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRandomizer : MonoBehaviour
{
    public GameObject[] puzzlePieces; // Array of puzzle pieces

    void Start()
    {
        ShufflePuzzlePieces(); // Call the shuffle function
    }

    void ShufflePuzzlePieces()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            int randomIndex = Random.Range(0, puzzlePieces.Length); // Get random index for shuffling

            // Swap the puzzle pieces
            GameObject temp = puzzlePieces[i];
            puzzlePieces[i] = puzzlePieces[randomIndex];
            puzzlePieces[randomIndex] = temp;
        }
    }
}