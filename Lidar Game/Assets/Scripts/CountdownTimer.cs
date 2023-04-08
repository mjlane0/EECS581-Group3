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