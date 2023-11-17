using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource winSound;

    private float nextLevelPause = 2.0f; // time in seconds before next level is loaded
    private bool touchCheckpoint = false;
    private void Start()
    {
        winSound = GetComponent<AudioSource>(); // reference to the audio
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !touchCheckpoint) // check if player and checkpoint are colliding
        {
            winSound.Play();
            touchCheckpoint = true;
            Invoke("FinishLevel", nextLevelPause); // call new level function after 2 seconds
        }
    }

    private void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load the next level
    }

}
