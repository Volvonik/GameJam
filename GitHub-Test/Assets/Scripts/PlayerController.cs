using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    BoxCollider2D boxCol;
    CircleCollider2D circleCol;
    Rigidbody2D rb;

    int colContidion = 0;

    public GameObject spawner;

    public float minSpeed = 10f;
    public float moveSpeed = 10f;
    public float maxSpeed = 13f;
    public float speedChange = 0.2f;

    float moveInput;
    bool facingRight = true;

    public float jumpForce = 10f;
    public float downJumpForce = 2f;
    public float velocityChangeDelay = .6f;

    public static bool isGrounded = false;
    bool isJumping = false;

    void Start()
    {
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        circleCol = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);

        if (facingRight == false && rb.velocity.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && rb.velocity.x <0)
        {
            Flip();
        }

        if (isJumping == true && isGrounded == true) 
        {
            rb.velocity = Vector2.up * jumpForce;
            Invoke("DownVelocity", velocityChangeDelay);

            isJumping = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            isJumping = true;
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown("left ctrl"))
        {
            if (colContidion % 2 == 0)
            {
                boxCol.enabled = false;
                circleCol.enabled = false;
                colContidion++;
            }
            else if (colContidion % 2 == 1)
            {
                boxCol.enabled = true;
                circleCol.enabled = true;
                colContidion++;
            }          
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    void DownVelocity()
    {
        rb.velocity += Vector2.down * downJumpForce;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lava")
        {
            transform.position = spawner.transform.position;

            rb.velocity = new Vector2 (0, 0);

            colContidion = 0;
            boxCol.enabled = true;
            circleCol.enabled = true;
        }
    }
}