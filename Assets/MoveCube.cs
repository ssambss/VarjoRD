using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    private int waypointNr;
    private float distance;

    void Start()
    {
        waypointNr = 0;
        transform.LookAt(waypoints[waypointNr].position);
    }


    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointNr].position);
        if(distance < 1f)
        {
            NextNr();
        }
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void NextNr()
    {
        waypointNr++;
        if(waypointNr >= waypoints.Length)
        {
            waypointNr = 0;
        }
        transform.LookAt(waypoints[waypointNr].position);
    }
}
