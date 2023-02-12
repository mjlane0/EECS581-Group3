using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]

    public float moveSpeed;
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
        if(!dead)
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
        rb.freezeRotation = false;
        if (collision.gameObject.tag == "Enemy")
        {
            dead = true;
            print("Hello");
        }
    }
}
