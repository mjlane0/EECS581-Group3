﻿/*
Name of Artifact: CountdownTimer.cs
Description: This script is designed to be used in a boss level, where it counts down from a specified value. Once the countdown reaches zero, the closing walls are deactivated, and the SetFinishJob method is called from another script, leading to the end of the game.
Programmer's Name: Azdeen Jeljalane, Sam Jerguson
Date Created: 4/8/2023
Dates Updated: 4/8/2023 - Description: Whole file was completed in one session. Author: Sam Jerguson
Preconditions: The script requires a Text component for the timer display, an array of wall GameObjects, a NavMeshAgent for the agent, and a reference to the player GameObject.
Postconditions: When the timer reaches zero, the walls are deactivated, the agent is disabled, and the SetFinishJob method is called, leading to the end of the game.
Error/exception conditions: None.
Side Effects: The script directly modifies the active state of wall GameObjects and disables the NavMeshAgent component.
Invariants: The initial timeRemaining value cannot be negative.
Known faults: None.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // 1 minute in seconds
    public Text timerText;
    public GameObject[] walls;
    public NavMeshAgent agent;
    public GameObject player;
    void Update()
    {
        // Check if the timer has finished
        if (timeRemaining > 0)
        {
            // Decrease the time remaining by the time since the last frame
            timeRemaining -= Time.deltaTime;

            // Update the timer text
            int minutes = (int)timeRemaining / 60;
            int seconds = (int)timeRemaining % 60;
            timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
        else
        {
            // The timer has finished, make the walls disappear
            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
            timerText.text = "Finish the Job";
            agent.enabled = false;
            player.GetComponent<PlayerMovement>().SetFinishJob();
            // Disable the script
            enabled = false;
        }
    }
}
