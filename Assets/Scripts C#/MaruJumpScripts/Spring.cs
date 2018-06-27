/// </summary>
/// JumpPlatform2D
/// Attach this script to the player.
/// <summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    public float springJump = 410;          // The player's jump height when hitting the trigger.
    float velocityY;                        // Variable that can be seen throughout the script and referenced to.

	// Update is called once per frame
	void Update ()
    {
        // References our player's current velocity.y
        velocityY = GetComponent<Rigidbody2D>().velocity.y;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with tag "JumpPlatform" and the velocity is less or equal to 0, then...
        if(other.tag == "Spring" && velocityY <= 0)
        {
            // Nullifies the player's current velocity (x and y) to 0.
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            // Increase the player's y force by jumpHeight.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, springJump));
        }
    }
}
