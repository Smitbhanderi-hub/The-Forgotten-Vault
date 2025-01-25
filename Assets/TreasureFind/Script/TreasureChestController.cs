using UnityEngine;

public class TreasureChestController : MonoBehaviour
{
    public Animator chestAnimator; // Animator for the chest
    public GameObject particleEffect; // Particle effect for treasure

    public void OpenChest()
    {
        chestAnimator.SetTrigger("Open"); // Trigger chest animation
        particleEffect.SetActive(true); // Activate particle effect
        Debug.Log("Treasure unlocked!");
    }
}