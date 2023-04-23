/*
Name of Artifact: PauseMenu.cs
Description: This script controls the functionality of the pause menu, including interaction with UI elements, button actions, and managing pause state.
Programmer's Name: Sam Jerguson
Date Created: 11/17/2022
Dates Updated: 2/27/2023 - Description: Added support for Levels 3 and 4. Author: Sam Jerguson
Preconditions: The script requires references to the pause menu, color menu, level menu, and UI GameObjects.
Postconditions: The pause menu will appear and function as expected when the game is paused.
Error/exception conditions: None.
Side Effects: The script modifies the active state of UI GameObjects and affects the game's time scale.
Invariants: None.
Known faults: None.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject colorMenu;
    public GameObject levelMenu;
    public bool paused = false;

    // UI elements for adjusting the position of UI components
    public GameObject ul;
    public GameObject ur;
    public GameObject dr;
    public GameObject dl;
    int presses;

    // Initialize the UI GameObjects
    void Start()
    {
        // Set the initial active state of UI GameObjects
        ul.SetActive(true);
        ur.SetActive(false);
        dr.SetActive(false);
        dl.SetActive(false);
        colorMenu.SetActive(false);
        levelMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle pause state when the Escape key is pressed
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == true)
                Resume();
            else
                Pause();
        }
    }

    // Pause the game and show the pause menu
    public void Pause()
    {
        // Set cursor to be visible and unlocked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Activate the pause menu
        pauseMenu.SetActive(true);

        // Freeze the game time
        Time.timeScale = 0f;

        // Set the paused state to true
        paused = true;
    }

    // Resume the game and hide the pause menu
    public void Resume()
    {
        // Set cursor to be invisible and locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Deactivate the pause menu and other menus
        pauseMenu.SetActive(false);
        colorMenu.SetActive(false);
        levelMenu.SetActive(false);

        // Unfreeze the game time
        Time.timeScale = 1f;

        // Set the paused state to false
        paused = false;
    }

    // Load the main menu scene
    public void MainMenu()
    {
        // Unfreeze the game time
        Time.timeScale = 1f;

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    // Show the color picker menu
    public void ColorPick()
    {
        // Activate the color menu
        colorMenu.SetActive(true);

        // Deactivate the pause menu
        pauseMenu.SetActive(false);
    }

    // Show the level picker menu
    public void LevelPick()
    {
        // Activate the level menu
        levelMenu.SetActive(true);

        // Deactivate the pause menu
        pauseMenu.SetActive(false);
    }

    // Go back to the pause menu from color or level picker menus
    public void BackToPause()
    {
        // Deactivate the color and level menus
        colorMenu.SetActive(false);
        levelMenu.SetActive(false);

        // Activate the pause menu
        pauseMenu.SetActive(true);
    }

    // Load Level 1 scene
    public void Level1()
    {
        // Unfreeze the game time
        Time.timeScale = 1f;

        // Load the Level 1 scene
        SceneManager.LoadScene("Level1");
    }

    // Load Level 2 scene
    public void Level2()
    {
        // Unfreeze the game time
        Time.timeScale = 1f;

        // Load the Level 2 scene
        SceneManager.LoadScene("Level2");
    }

    // Load Level 3 scene
    public void Level3()
    {
        // Unfreeze the game time
        Time.timeScale = 1f;

        // Load the Level 3 scene
        SceneManager.LoadScene("Level3");
    }

    // Load Level 4 scene
    public void Level4()
    {
        // Unfreeze the game time
        Time.timeScale = 1f;

        // Load the Level 4 scene
        SceneManager.LoadScene("Level4");
    }

    // Adjust the position of UI elements on the screen
    public void AdjustUI()
    {
        // Increment the number of presses
        presses++;

        // Calculate the new UI position based on the number of presses
        int pFinal = presses % 4;
        switch(pFinal)
        {
            case 0:
                // Set the UI elements to the upper-left corner
                ul.SetActive(true);
                ur.SetActive(false);
                dr.SetActive(false);
                dl.SetActive(false);
                break;
            case 1:
                // Set the UI elements to the upper-right corner
                ul.SetActive(false);
                ur.SetActive(true);
                dr.SetActive(false);
                dl.SetActive(false);
                break;
            case 2:
                // Set the UI elements to the bottom-right corner
                ul.SetActive(false);
                ur.SetActive(false);
                dr.SetActive(true);
                dl.SetActive(false);
                break;
            case 3:
                // Set the UI elements to the bottom-left corner
                ul.SetActive(false);
                ur.SetActive(false);
                dr.SetActive(false);
                dl.SetActive(true);
                break;
            default:
                break;
        }
    }

}
