using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour
{
    public Animator chestAnimator;       // Animator for the chest
    public GameObject confettiEffect;   // Particle effect for treasure
    public string nextSceneName = "EndingScreen3"; // Name of the next scene
    private bool isOpened = false;      // To prevent multiple triggers

    public void OpenChest()
    {
        if (isOpened) return; // Ensure the chest is only opened once
        isOpened = true;

        // Play chest opening animation
        if (chestAnimator != null)
        {
            chestAnimator.SetTrigger("Open");
        }

        // Activate confetti or particle effects
        if (confettiEffect != null)
        {
            confettiEffect.SetActive(true);
        }

        // Redirect to the next scene after 5 seconds
        Invoke(nameof(LoadNextScene), 5f); // 5-second delay
    }

    public void CollectChest()
    {
        // Optionally destroy the chest or deactivate it
        Destroy(gameObject); // Removes the chest from the scene
        Debug.Log("Chest collected!");
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}