using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    BoxCollider2D col;
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
    public static float extraJumps = 1;

    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        
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
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps --;
        }
        else if (Input.GetKeyDown("space") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            Invoke("DownVelocity", velocityChangeDelay);
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown("left ctrl"))
        {
            if (colContidion % 2 == 0)
            {
                col.enabled = false;
                colContidion++;
            }
            else if (colContidion % 2 == 1)
            {
                col.enabled = true;
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
        rb.velocity = Vector2.down * downJumpForce;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Lava")
        {
            transform.position = spawner.transform.position;

            rb.velocity = new Vector2 (0, 0);

            colContidion = 0;
            col.enabled = true;
        }
    }
}
