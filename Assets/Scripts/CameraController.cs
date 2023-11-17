using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float zPos = 10.0f;
    [SerializeField] private Transform player;

    private void Update()
    {
        // make camera follower player based on player position so it doesn't rotate when player falls off
        transform.position = new Vector3(player.position.x, player.position.y, -zPos);
    }
}
