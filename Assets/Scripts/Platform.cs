using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) // distinguish between the box colliders
    {
        if (collision.gameObject.name == "Player") // check if player is colliding with platform
        {
            collision.gameObject.transform.SetParent(transform); // sets player as a child of the moving platform
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // function for when player leaves platform
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null); // removes parent

        }
    }
}
