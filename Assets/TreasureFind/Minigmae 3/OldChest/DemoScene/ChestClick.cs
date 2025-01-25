using UnityEngine;

public class ChestClick : MonoBehaviour
{
    private bool isOpen = false; // Tracks the state of the chest

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is this chest
                if (hit.transform == transform)
                {
                    // Play animation based on the chest state
                    Animation chestAnimation = GetComponent<Animation>();
                    if (!chestAnimation.isPlaying)
                    {
                        if (!isOpen)
                        {
                            chestAnimation["ChestAnim"].speed = 1.0f; // Open animation
                        }
                        else
                        {
                            chestAnimation["ChestAnim"].time = chestAnimation["ChestAnim"].length; // Reset to the end
                            chestAnimation["ChestAnim"].speed = -1.0f; // Close animation
                        }
                        chestAnimation.Play("ChestAnim");
                        isOpen = !isOpen; // Toggle state
                    }
                }
            }
        }
    }
}
