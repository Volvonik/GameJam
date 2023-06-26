using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BoxCollider2D col;

    public Rigidbody2D rb;

    public float minSpeed = 10;
    public float moveSpeed = 10;
    public float maxSpeed = 13;
    public float speedChange = 0.2;

    void Start ()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        //float moveAmount = moveSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;

        //transform.Translate(moveAmount, 0, 0);
    }
}
