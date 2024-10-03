using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Create a public reference to the player - we will asign this using the Unity editor
    public GameObject player; 

    void Update()
    {
      // Change our position relative to the players position
      transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);  // Getting the positions 
    }
}

