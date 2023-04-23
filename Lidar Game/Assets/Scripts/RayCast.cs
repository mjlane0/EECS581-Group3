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

	public LayerMask NotEnemy, Enemy, Exit;
	public GameObject dot;
	public Material whiteMat, blueMat, pinkMat;
	public Object prefabRed, prefabGreen;
	public float Spread;
	public float lowSpread, medSpread, highSpread;
	public float lowDistance, medDistance, highDistance;
	public float ShootDistance;
	public GameObject pauseMenu;
    public bool isPaused;
	int qPresses = 0;
	int pPresses = 0;
	AudioSource audioData;
	bool audioOn = false;

	void Start()
	{
		audioData = GetComponent<AudioSource>();
		dot.GetComponent<MeshRenderer> ().material = whiteMat;
		Spread = medSpread;
		ShootDistance = medDistance;
	}

	void Update()
	{
		print(audioOn);
		isPaused = pauseMenu.GetComponent<PauseMenu>().paused;
        if(!isPaused)
		{
			CheckModeSwitch();
			CheckColorSwitch();

			Ray ray = new Ray(transform.position, new Vector3(Random.Range(transform.up.x - Spread, transform.up.x + Spread), Random.Range(transform.up.y - Spread, transform.up.y + Spread), Random.Range(transform.up.z - Spread, transform.up.z + Spread)));
			RaycastHit hitInfo;
			if (Input.GetKey(KeyCode.Mouse0))
			{
				if(audioOn == false)
				{
					audioData.Play(0);
					audioOn = true;
				}
				if (Physics.Raycast(ray, out hitInfo, ShootDistance, NotEnemy))
				{
					Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
					Object.Instantiate(dot, hitInfo.point, Quaternion.identity);
				}
				else
				{
					Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
				}
				if (Physics.Raycast(ray, out hitInfo, ShootDistance, Enemy))
				{
					Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
					Object.Instantiate(prefabRed, hitInfo.point, Quaternion.identity);
				}
				if (Physics.Raycast(ray, out hitInfo, ShootDistance, Exit))
				{
					Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
					Object.Instantiate(prefabGreen, hitInfo.point, Quaternion.identity);
				}
			}
			else
			{
				if(audioOn == true)
				{
					audioData.Pause();
					audioOn = false;
				}
			}
		}

	}

	void CheckModeSwitch()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			int qFinal = qPresses % 3;
			qPresses++;
			print("Spread Mode: " + qFinal);
			switch(qFinal)
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

	void CheckColorSwitch()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			pPresses++;
			int pFinal = pPresses % 3;
			print("Color: " + pFinal);
			switch(pFinal)
			{
				case 0:
				{
					dot.GetComponent<MeshRenderer> ().material = whiteMat;		
					break;
				}
				case 1:
				{
					 dot.GetComponent<MeshRenderer> ().material = blueMat;	
					break;
				}
				case 2:
				{
					 dot.GetComponent<MeshRenderer> ().material = pinkMat;	
					break;
				}
				default:
					break;
			}
		}
	}
	public void ColorWhite()
	{
		dot.GetComponent<MeshRenderer> ().material = whiteMat;
	}
	public void ColorBlue()
	{
		dot.GetComponent<MeshRenderer> ().material = blueMat;
	}
	public void ColorPink()
	{
		dot.GetComponent<MeshRenderer> ().material = pinkMat;
	}
}
