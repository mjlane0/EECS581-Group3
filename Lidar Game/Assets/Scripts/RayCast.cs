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
	public float ShootDistance;


	void Update()
	{

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
}