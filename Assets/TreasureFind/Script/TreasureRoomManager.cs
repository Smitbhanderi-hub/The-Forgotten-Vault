using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureRoomManager : MonoBehaviour
{
    public float detectionRange = 2.0f; // Range to detect the chest
    private GameObject chest; // Reference to the spawned chest
    private bool chestFound = false;

    void Start()
    {
        // Find the spawned chest using ChestSpawner
        ChestSpawner chestSpawner = FindObjectOfType<ChestSpawner>();
        if (chestSpawner != null)
        {
            chest = chestSpawner.GetSpawnedChest();
        }
    }

    void Update()
    {
        if (chest != null && !chestFound)
        {
            // Check if the chest is within the detection range
            float distance = Vector3.Distance(Camera.main.transform.position, chest.transform.position);

            if (distance <= detectionRange)
            {
                chestFound = true; // Mark chest as found
                Debug.Log("Treasure is within reach! Tap to open it.");
            }
        }

        if (chestFound && Input.GetMouseButtonDown(0)) // Detect screen tap
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the raycast hits the chest
                if (hit.collider.gameObject == chest)
                {
                    Debug.Log("Chest tapped!");
                    chest.GetComponent<ChestController>().OpenChest(); // Open the chest
                    Invoke(nameof(CollectAndFinish), 2.0f); // Delay collection and scene transition
                }
                else
                {
                    Debug.Log("Raycast hit something else: " + hit.collider.gameObject.name);
                }
            }
            else
            {
                Debug.Log("Raycast didn't hit anything.");
            }
        }
    }

    // Method to collect the chest and finish the game
    private void CollectAndFinish()
    {
        if (chest != null)
        {
            chest.GetComponent<ChestController>().CollectChest(); // Collect the chest
            SceneManager.LoadScene("EndingScreen3"); // Load the next scene
        }
    }
}