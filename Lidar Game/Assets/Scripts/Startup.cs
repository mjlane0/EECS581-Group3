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
