using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    public GameObject pauseMenu;
    public bool isPaused;

    float xRotation;
    float yRotation;
    public GameObject player;
    bool dead;
    public float deathCamRotate;


    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        dead = player.GetComponent<PlayerMovement>().dead;
        isPaused = pauseMenu.GetComponent<PauseMenu>().paused;
        if(!isPaused && !dead)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;
            yRotation += mouseX;
            xRotation -= mouseY;

            //clamp rotation at 90 degrees
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate cam adn player
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        if(dead)
        {
            if (transform.localRotation.eulerAngles.z < 90.0f)
            {
                transform.localRotation *= Quaternion.Euler(0.0f, 0.0f, deathCamRotate * Time.deltaTime);
            }
        }
    }
}
