using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            PlayerController.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            PlayerController.isGrounded = false;
        }
    }

    private void Update()
    {
        if (PlayerController.isGrounded == true)
        {
            PlayerController.extraJumps = 1;
        }
    }
}
