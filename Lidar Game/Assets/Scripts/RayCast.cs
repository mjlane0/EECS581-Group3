using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

	public LayerMask NotEnemy;
	public LayerMask Enemy;
	public Object prefabWhite;
	public Object prefabRed;
	public float Spread;
	public float lowSpread, medSpread, highSpread;
	public float lowDistance, medDistance, highDistance;
	public float ShootDistance;
	int qPresses = 0;

	void Start()
	{
		Spread = medSpread;
		ShootDistance = medDistance;
	}

	void Update()
	{
		CheckModeSwitch();

		Ray ray = new Ray(transform.position, new Vector3(Random.Range(transform.up.x - Spread, transform.up.x + Spread), Random.Range(transform.up.y - Spread, transform.up.y + Spread), Random.Range(transform.up.z - Spread, transform.up.z + Spread)));
		RaycastHit hitInfo;
		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (Physics.Raycast(ray, out hitInfo, ShootDistance, NotEnemy))
			{
				Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
				Object.Instantiate(prefabWhite, hitInfo.point, Quaternion.identity);
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
}