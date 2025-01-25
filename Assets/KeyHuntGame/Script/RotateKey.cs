using UnityEngine;

public class RotateKey : MonoBehaviour
{
    public float rotationSpeed = 50f; // Rotation speed in degrees per second

    void Start()
    {
        rotationSpeed = Random.Range(30f, 100f); // Random speed between 30 and 100
    }

    void Update()
    {
        // Rotate the key around its local Z-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}