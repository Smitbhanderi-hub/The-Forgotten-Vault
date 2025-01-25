using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    public Key keyPrefabSet1; // Prefab for Set1 keys
    public Key keyPrefabSet2; // Prefab for Set2 keys

    private int totalKeys = 10;
    private int set1Keys = 7; // Keys in Set1
    private int set2Keys = 3; // Keys in Set2
    private int collectedKeys = 0;

    private List<Key> currentKeys = new List<Key>();
    private bool gameStarted = false;

    public void StartGame()
    {
        SpawnKeys(keyPrefabSet1, set1Keys); // Spawn Set1 keys
        SpawnKeys(keyPrefabSet2, set2Keys); // Spawn Set2 keys
        gameStarted = true;
    }

    private void SpawnKeys(Key prefab, int count)
    {
        int spawnedKeys = 0;

        while (spawnedKeys < count)
        {
            Vector3 position = Camera.main.transform.position +
                               new Vector3(Random.Range(-5, 5), Random.Range(-1, 1), Random.Range(-5, 5));

            // Ensure no overlap
            bool isOverlapping = false;
            foreach (Key key in currentKeys)
            {
                if (Vector3.Distance(position, key.transform.position) < 0.5f)
                {
                    isOverlapping = true;
                    break;
                }
            }

            if (isOverlapping) continue;

            Key newKey = Instantiate(prefab, position, Quaternion.identity);
            currentKeys.Add(newKey);
            spawnedKeys++;
        }
    }

    void Update()
    {
        if (!gameStarted) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Key selectedKey = hit.transform.GetComponentInChildren<Key>();
                if (selectedKey == null) return;

                collectedKeys++;
                Destroy(selectedKey.gameObject);
                currentKeys.Remove(selectedKey);

                if (collectedKeys == 3)
                {
                    SceneManager.LoadScene("EndingScreen2"); // Load the next scene
                }
            }
        }
    }
}