using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chestPrefab; // Chest prefab
    public float spawnDistance = 2.0f; // Distance in front of the camera to spawn the chest
    public float spawnHeight = 0.0f; // Adjust height if needed

    private GameObject spawnedChest;

    void Start()
    {
        SpawnChest();
    }

    private void SpawnChest()
    {
        // Calculate spawn position in front of the camera
        Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * spawnDistance;
        spawnPosition.y = spawnHeight;

        // Instantiate the chest prefab at the calculated position
        spawnedChest = Instantiate(chestPrefab, spawnPosition, Quaternion.identity);
    }

    public GameObject GetSpawnedChest()
    {
        return spawnedChest; // Return the spawned chest for other scripts
    }
}