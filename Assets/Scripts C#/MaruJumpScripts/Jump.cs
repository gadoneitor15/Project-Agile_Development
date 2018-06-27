using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public bool grounded;                     // True or false, based on whether the player is grounded.
    public float jumpHeight = 10;             // The height of the jump.
    public Transform groundCheck;             // Object which will check if the player is grounded.
    public float groundRadius = .05f;         // Radius round the groundCheck object that will detect whether the player is grounded or not.
    public LayerMask ground;                  // Decides which layers count as grounded.

    float velocityY;

    /* Using FixedUpdate() here, because FixedUpdate can run multiple times for each frame,
     * depending on how many physics frames per second are set in the time settings, and how fast/slow the frame rate is.
     */ 
    void FixedUpdate ()
    {
        velocityY = GetComponent<Rigidbody2D>().velocity.y;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);

        // Checks if the player is grounded and velocity Y is less or equal to zero.
        if (grounded && velocityY <= 0)
        {   
            // Assigns velocity and force to the player (the player is able to jump).
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight));
        }
	}
}
