using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wait : MonoBehaviour
{
    public float wait_time = 80f; // Updated to match the video duration

    void Start()
    {
        StartCoroutine(wait_for_intro());
    }

    IEnumerator wait_for_intro()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadSceneAsync(1); // Load the next scene
    }
}