/*
RayCast Artifact
Sam Jerguson
Created October 23, 2022
Revised December 4 2022
This file controls and automates all raycasting features within the game
Preconditions: 
- The RayCast script is attached to a GameObject in the game.
- The PauseMenu script is attached to a separate GameObject in the game and is functioning properly.
Postconditions: 
- The RayCast script will control and automate all raycasting features within the game.
Error/exception conditions: 
- If the game is not running or the RayCast script is not attached to a GameObject in the game, an error will occur.
- If the PauseMenu script is not attached to a separate GameObject or is not functioning properly, the isPaused variable may not be set correctly and could result in errors.
Side Effects: 
none
No known Faults
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RayCast : MonoBehaviour
{

	public LayerMask NotEnemy, Enemy, Exit; // LayerMasks for different object types
	public GameObject dot; // The dot prefab for marking raycast hits
	public Material whiteMat, blueMat, pinkMat; // Materials for changing the dot color
	public Object prefabRed, prefabGreen; // Prefabs for marking different types of raycast hits
	public float Spread; // The spread of the raycast
	public float lowSpread, medSpread, highSpread; // Preset spread values
	public float lowDistance, medDistance, highDistance; // Preset shooting distance values
	public float ShootDistance; // The shooting distance
	public GameObject pauseMenu; // Reference to the pause menu
	public bool isPaused; // Indicates if the game is paused
	int qPresses = 0; // Counts the number of times the Q key is pressed
	int pPresses = 0; // Counts the number of times the P key is pressed
	AudioSource audioData; // Audio source for playing sound
	bool audioOn = false; // Indicates if the audio is currently playing

	void Start()
	{
		audioData = GetComponent<AudioSource>();
		dot.GetComponent<MeshRenderer>().material = whiteMat;
		Spread = medSpread;
		ShootDistance = medDistance;
	}

	void Update()
	{
		print(audioOn);
		isPaused = pauseMenu.GetComponent<PauseMenu>().paused;
		
		if (!isPaused)
		{
			CheckModeSwitch(); // Check if the user wants to change the shooting mode
			CheckColorSwitch(); // Check if the user wants to change the dot color

			// Create a ray with random spread around the transform's up direction
			Ray ray = new Ray(transform.position, new Vector3(Random.Range(transform.up.x - Spread, transform.up.x + Spread), Random.Range(transform.up.y - Spread, transform.up.y + Spread), Random.Range(transform.up.z - Spread, transform.up.z + Spread)));
			RaycastHit hitInfo;

			// Handle raycasts when the left mouse button is held down
			if (Input.GetKey(KeyCode.Mouse0))
			{
				// Play audio when shooting
				if (audioOn == false)
				{
					audioData.Play(0);
					audioOn = true;
				}

				// Check if the raycast hits an object in the NotEnemy layer
				if (Physics.Raycast(ray, out hitInfo, ShootDistance, NotEnemy))
				{
					Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
					Object.Instantiate(dot, hitInfo.point, Quaternion.identity);
				}
				else
				{
					Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
				}

				// Check if the raycast hits an object in the Enemy layer
				if (Physics.Raycast(ray, out hitInfo, ShootDistance, Enemy))
				{
					Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
					Object.Instantiate(prefabRed, hitInfo.point, Quaternion.identity);
				}

				// Check if the raycast hits an object in the Exit layer
				if (Physics.Raycast(ray, out hitInfo, ShootDistance, Exit))
				{
					Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
					Object.Instantiate(prefabGreen, hitInfo.point, Quaternion.identity);
				}
			}
			// Pause audio when not shooting
			else
			{
				if (audioOn == true)
				{
					audioData.Pause();
					audioOn = false;
				}
			}
		}
	}

	// Check if the user wants to change the shooting mode and update the Spread and ShootDistance accordingly
	void CheckModeSwitch()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			int qFinal = qPresses % 3;
			qPresses++;
			print("Spread Mode: " + qFinal);
			switch (qFinal)
			{
				case 0:
				{
					Spread = lowSpread;
					ShootDistance = highDistance;
					break;
				}
				case 1:
				{
					Spread = medSpread;
					ShootDistance = medDistance;
					break;
				}
				case 2:
				{
					Spread = highSpread;
					ShootDistance = lowDistance;
					break;
				}
				default:
					break;
			}
		}
	}

	// Check if the user wants to change the dot color and update the dot's material accordingly
	void CheckColorSwitch()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			pPresses++;
			int pFinal = pPresses % 3;
			print("Color: " + pFinal);
			switch (pFinal)
			{
				case 0:
				{
					dot.GetComponent<MeshRenderer>().material = whiteMat;
					break;
				}
				case 1:
				{
					dot.GetComponent<MeshRenderer>().material = blueMat;
					break;
				}
				case 2:
				{
					dot.GetComponent<MeshRenderer>().material = pinkMat;
					break;
				}
				default:
					break;
			}
		}
	}

	// Set the dot color to white
	public void ColorWhite()
	{
		dot.GetComponent<MeshRenderer>().material = whiteMat;
	}

	// Set the dot color to blue
	public void ColorBlue()
	{
		dot.GetComponent<MeshRenderer>().material = blueMat;
	}

	// Set the dot color to pink
	public void ColorPink()
	{
		dot.GetComponent<MeshRenderer>().material = pinkMat;
	}
}
