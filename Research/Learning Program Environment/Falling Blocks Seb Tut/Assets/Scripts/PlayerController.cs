using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float screenHalfWidth;
    public float speed = 7;
    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth; //aspect is the aspect ratio aka width/height, and orthographicSize is height. We want width, and multiplying by height cancels the height
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float velocity = input * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        if(transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        }
        if (transform.position.x < -screenHalfWidth)
        {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "Obstacle")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
