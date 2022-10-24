using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

	public LayerMask mask;
	public Object prefab;
	public float Spread;
	public float ShootDistance;


	void Update()
	{

		Ray ray = new Ray(transform.position, new Vector3(Random.Range(transform.up.x - Spread, transform.up.x + Spread), Random.Range(transform.up.y - Spread, transform.up.y + Spread), Random.Range(transform.up.z - Spread, transform.up.z + Spread)));
		RaycastHit hitInfo;
		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (Physics.Raycast(ray, out hitInfo, ShootDistance))
			{
				Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
				Object.Instantiate(prefab, hitInfo.point, Quaternion.identity);
			}
			else
			{
				Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
			}
		}

	}
}