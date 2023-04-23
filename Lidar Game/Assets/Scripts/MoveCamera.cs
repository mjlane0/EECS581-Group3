/*
Name of Artifact: MoveCamera.cs
Description: This script sets the position of the camera during gameplay, as long as the player is alive. When the player is dead, the camera position remains unchanged.
Programmer's Name: Sam Jerguson
Date Created: 10/23/2022
Dates Updated: 2/11/2023 - Description: Added a "dead" variable that keeps track of whether the player has died, changing the camera's behavior accordingly. Author: Sam Jerguson
Preconditions: The script requires a reference to the desired camera position (Transform), and a reference to the player GameObject.
Postconditions: The camera's position will be updated during gameplay as long as the player is alive.
Error/exception conditions: None.
Side Effects: The script modifies the position of the camera GameObject during gameplay.
Invariants: None.
Known faults: None.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform cameraPosition;
    public GameObject player;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = player.GetComponent<PlayerMovement>().dead; //get the "dead" variable from the PlayerMovement script
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead) //when the players not dead, move the camera.
            transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y + .5f, cameraPosition.position.z);
    }
}
