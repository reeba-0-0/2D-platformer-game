using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private const float speed = 2.0f; 
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.05f) // check distance between waypoints
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length) // check if end of array is reached
            {
                currentWaypointIndex = 0; // set index back to 0
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
