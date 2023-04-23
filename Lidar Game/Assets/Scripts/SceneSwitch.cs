/*
Scene Switch Artifact
Sam Jerguson
Created November 6, 2022
Revised Feb 11, 2022
This file is able to use the scene manager to get various active scenes and load other enviornments.
Preconditions: 
- The scene that contains this script is included in the build settings.
- The tag "Player" is assigned to the player GameObject in the scene.
Postconditions: 
- The next scene in the build settings is loaded when the player collides with the GameObject that this script is attached to.
Error/exception conditions: 
- If there is no next scene in the build settings, an error may occur.
Side Effects: 
- Any objects that are not marked as "DontDestroyOnLoad" may be destroyed when the scene switches.
No known Faults
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
