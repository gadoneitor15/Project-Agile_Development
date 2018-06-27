using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour {

    public static float screenLeft = -3.95f;
    public static float screenRight = 3.91f;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // If the player's position is below -3.94f, then...
		if (transform.position.x <= screenLeft)
        {
            // Our new player position will be:
            transform.position = new Vector3(screenRight, transform.position.y, transform.position.z);
        }
        // Else if the player's position is above 3.94f, then...
        else if (transform.position.x >= screenRight)
        {
            // Our new player position will be:
            transform.position = new Vector3(screenLeft, transform.position.y, transform.position.z);
        }
	}
}
