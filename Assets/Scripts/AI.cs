using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distanceThreshold = 0.2f;
    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, currentWaypoint.position) <= distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        }
    }
}
