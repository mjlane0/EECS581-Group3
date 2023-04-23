/*
Bootup
Rishab Bhat, Sam Jerguson
Created Feb 27, 2023
Revised Feb 27, 2023
This file controls the unity engine bootup, and begins the music as well as the initiial start of the game along with an update function that is called.
Preconditions: 
- none
Postconditions: 
- The game's background music starts playing and the game is ready to be played.
Error/exception conditions: 
- If the audio clip is not found or cannot be played, an error message will be displayed.
Side Effects: 
-  None
No known Faults
No known Faults
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip musicClip; // The audio clip to play
    private AudioSource musicSource;

    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true; //loops
        musicSource.Play(); //play the actual clip
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
