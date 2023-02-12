using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform cameraPosition;
    public GameObject player;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = player.GetComponent<PlayerMovement>().dead;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead)
            transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y + .5f, cameraPosition.position.z);
    }
}
