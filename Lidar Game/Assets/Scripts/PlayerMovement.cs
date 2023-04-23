/*
Player Movement Artifact

Sam Jerguson

Created October 23, 2022
Revised April 8, 2022

This file describes and controls the player's movement in the game including move speed, player cam, and other fundamental assets that aid the 
player in traversing the enviornment

No known Faults


*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    public bool finishJob = false;
    public float moveSpeed;
    public GameObject uiObj;
    public Transform playerCam;
    public float sensX;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public float groundDrag;
    float yRotation;
    public Vector3 startPos;
    public bool dead;
    AudioSource audioData;
	bool audioOn = false;
 bool go; //gameover
    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        dead = false;
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        go = uiObj.GetComponent<UI>().go;
        MyInput();
        rb.drag = groundDrag;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        //print(transform.position.y);
        if(transform.position.y < 1.41)
        {
            print("yes");
            transform.position = startPos;
        }

    }

    private void FixedUpdate()
    {
        if(!go)
            MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }



    private void MovePlayer()
    {
 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        if(moveDirection.magnitude > 0)
        {
            if(audioOn == false)
		    {
			    audioData.Play(0);
			    audioOn = true;
		    }
        }
        else if(audioOn == true)
        {
            audioData.Pause();
			audioOn = false;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(finishJob)
        {
            SceneManager.LoadScene(0);
        }
        rb.freezeRotation = false;
        if (collision.gameObject.tag == "Enemy")
        {
            dead = true;
            print("Hello");
        }
    }

    public void SetFinishJob()
    {
        finishJob = true;
    }
}
