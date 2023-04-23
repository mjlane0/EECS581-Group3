/*
Name of Artifact: PlayerCam.cs
Description: Controls the camera attached to the player, including rotating it in ways that make it seem like the player died when they run out of lives. The script also handles camera movement during gameplay and disables it when the game is paused or in game over state.
Programmer's Name: Sam Jerguson
Date Created: 10/23/2022
Dates Updated: 11/17/2022 - Description: Disallows camera movement while the game is paused. Author: Sam Jerguson
2/11/2023 - Description: Rotates the camera in a way that makes it seem like the player died when they run out of lives. Author: Sam Jerguson
2/27/2023 - Description: Changed "dead" variable to "go" (game over). Author: Sam Jerguson
Preconditions: The script requires a reference to the player GameObject, UI GameObject, and pauseMenu GameObject. Sensitivity values for X and Y axes, and a deathCamRotate value must be provided.
Postconditions: The camera will follow and rotate based on the player's mouse input during gameplay, disable movement when paused, and simulate a death rotation when the player runs out of lives.
Error/exception conditions: None.
Side Effects: The script modifies the camera's rotation based on player input and game states.
Invariants: The sensitivity values and deathCamRotate must be non-negative.
Known faults: None.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    // References to other game objects
    public GameObject uiObj;
    public Transform orientation;
    public GameObject pauseMenu;
    public GameObject player;

    // Camera rotation variables
    private float xRotation;
    private float yRotation;

    // Player status variables
    private bool dead;
    private bool go; // Game over

    // Camera rotation speed when player dies
    public float deathCamRotate;

    // Game state variable
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player's death status and game over status from other components
        dead = player.GetComponent<PlayerMovement>().dead;
        go = uiObj.GetComponent<UI>().go;

        // Get the paused status from the PauseMenu component
        isPaused = pauseMenu.GetComponent<PauseMenu>().paused;

        // Check if the game is not paused and not in game over state
        if (!isPaused && !go)
        {
            // Get mouse input
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

            // Update rotation variables
            yRotation += mouseX;
            xRotation -= mouseY;

            // Clamp rotation at 90 degrees
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // Rotate camera and player orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        // Check if the game is in a game over state
        if (go)
        {
            // Rotate the camera to simulate player's death if the rotation is less than 90 degrees
            if (transform.localRotation.eulerAngles.z < 90.0f)
            {
                transform.localRotation *= Quaternion.Euler(0.0f, 0.0f, deathCamRotate * Time.deltaTime);
            }
        }
    }
}
