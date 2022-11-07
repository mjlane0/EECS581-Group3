using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RayCast : MonoBehaviour
{

	public LayerMask NotEnemy;
	public LayerMask Enemy;
	public GameObject dot;
	public Material whiteMat, blueMat, pinkMat;
	public Object prefabRed;
	public float Spread;
	public float lowSpread, medSpread, highSpread;
	public float lowDistance, medDistance, highDistance;
	public float ShootDistance;
	int qPresses = 0;
	int pPresses = 0;


	void Start()
	{
		dot.GetComponent<MeshRenderer> ().material = whiteMat;
		Spread = medSpread;
		ShootDistance = medDistance;
	}

	void Update()
	{
		CheckModeSwitch();
		CheckColorSwitch();

		Ray ray = new Ray(transform.position, new Vector3(Random.Range(transform.up.x - Spread, transform.up.x + Spread), Random.Range(transform.up.y - Spread, transform.up.y + Spread), Random.Range(transform.up.z - Spread, transform.up.z + Spread)));
		RaycastHit hitInfo;
		if (Input.GetKey(KeyCode.Mouse0))
		{
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
}