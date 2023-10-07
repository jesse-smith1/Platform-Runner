using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWayPointMover : MonoBehaviour
{
  //creating an array to put more then one "waypoint" in.
  //GameObject is objects in the heirachy.
  //Giving it the value of an array.
  //naming it waypoints
  [SerializeField] private GameObject[] waypoints;

  private int currentWaypointIndex = 0;

  [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
   private void Update()
    {
      if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
      {
        currentWaypointIndex++;
        if(currentWaypointIndex >= waypoints.Length)
        {
          currentWaypointIndex = 0;
        }
      }
       transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); 
    }
}
