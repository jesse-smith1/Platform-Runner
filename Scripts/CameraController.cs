using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
 [SerializeField] private Transform player;
    private void Update()
    {
      //lowercase transform - refers to the Transform of the same object player is in.
      //dont have to write getComponent.
      //Setting the position to a new Vector3 (because we are using 3 variables x,y,z)
      //player is used as the variable, position of camera is at the player postion x
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
