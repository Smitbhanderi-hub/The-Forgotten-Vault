using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int totalPieces = 9;
    private int placedPieces = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckCompletion()
    {
        placedPieces++;
        if (placedPieces == totalPieces)
        {
            Debug.Log("Puzzle Complete!");
            Invoke("LoadNextMinigame", 2f);
        }
    }

    private void LoadNextMinigame()
    {
        SceneManager.LoadScene("EndingScreen");
    }
}