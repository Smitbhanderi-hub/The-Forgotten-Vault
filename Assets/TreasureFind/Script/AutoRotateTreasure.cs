using UnityEngine;

public class AutoRotateTreasure : MonoBehaviour
{
    public float rotationSpeed = 20f;  // Speed of rotation

    void Update()
    {
        // Rotate the chest around the Y-axis (horizontal rotation)
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}