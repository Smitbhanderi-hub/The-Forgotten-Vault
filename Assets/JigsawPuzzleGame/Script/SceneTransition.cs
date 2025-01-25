using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadWelcomeScreen()
    {
        SceneManager.LoadScene("WelcomeScreen"); // Replace with the exact name of your welcome screen
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("JigsawGame"); // Replace with the exact name of your game screen
    }

    public void Game1Success()
    {
        SceneManager.LoadScene("EndingScreen1"); // Replace with the exact name of your welcome screen
    }

    public void LoadGame2()
    {
        SceneManager.LoadScene("KeyHuntGame"); // Replace with your Game Screen name
    }

    public void Game2Success()
    {
        SceneManager.LoadScene("EndingScreen2"); // Replace with your Game Screen name
    }
    public void LoadWelcomeScreen3()
    {
        SceneManager.LoadScene("WelcomeScreen3"); // Replace with your Game Screen name
    }
    public void LoadGame3()
    {
        SceneManager.LoadScene("TresaureHunt"); // Replace with your Game Screen name
    }
    public void Game3Success()
    {
        SceneManager.LoadScene("EndingScreen3"); // Replace with your Game Screen name
    }
}