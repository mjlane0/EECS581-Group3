/*
Room Enviornment Artifact
Sam Jerguson
Created April 8, 2022
Revised April 8, 2022
This file controls the walls in the enviornment of the game, through the 4 wall variables and an update function it is able to calculate and move the position of the walls.
No known Faults
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShrinker : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public float shrinkSpeed = 1f;
    

    private Vector3 center;
    private Vector3[] initialPositions;

    void Start()
    {
        // Store the initial positions of the walls
        initialPositions = new Vector3[] {
            wall1.transform.position,
            wall2.transform.position,
            wall3.transform.position,
            wall4.transform.position
        };

        // Calculate the center of the room
        center = (wall1.transform.position + wall2.transform.position + wall3.transform.position + wall4.transform.position) / 4;
    }

    void Update()
    {
        // Move the walls towards the center
        wall1.transform.position = Vector3.MoveTowards(wall1.transform.position, center, shrinkSpeed * Time.deltaTime);
        wall2.transform.position = Vector3.MoveTowards(wall2.transform.position, center, shrinkSpeed * Time.deltaTime);
        wall3.transform.position = Vector3.MoveTowards(wall3.transform.position, center, shrinkSpeed * Time.deltaTime);
        wall4.transform.position = Vector3.MoveTowards(wall4.transform.position, center, shrinkSpeed * Time.deltaTime);
    }
}
