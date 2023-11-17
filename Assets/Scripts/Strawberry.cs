using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strawberry : MonoBehaviour
{
    private int strawberryCounter = 0;

    [SerializeField] private Text strawberryText; // access text ui component

    [SerializeField] private AudioSource collectAudio; // access text ui component

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Strawberry")) // check if player has collided with strawberry
        {
            collectAudio.Play();
            Destroy(collision.gameObject); // if so, destroy it
            strawberryCounter++; // increment the amount of strawberries collected
            strawberryText.text = "Strawberries: " + strawberryCounter; // update text to display strawberries collected
        }
    }
}
