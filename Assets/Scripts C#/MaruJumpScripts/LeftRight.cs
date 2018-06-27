using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour {

    float platformSpeed = 2f;
    bool endPoint;
    Enemy enemy;

    // Use this for initialization.
    void Start()
    {
        // Makes it so you can acces the variables screenBoundaryLeft and screenBoundaryRight from another class.

        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame

	// Update is called once per frame
	void Update ()
    {
        // Checks if endPoint is true.
        if (endPoint)
        {
            // If so, then adds Vector3.right * platformSpeed * Time.deltaTime to the transform.Position.
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }	
        else
        {
            // Else it substracts Vector3.right * platformSpeed * Time.deltaTime from the transform.Position.
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

        // Checks if the transform.position.x is INSIDE of boundary of the left side of the screen.
        if (transform.position.x >= Enemy.screenBoundaryLeft)
        {
           
            endPoint = false;
        }

        // Checks if the transform.position.x is INSIDE of boundary of the right side of the screen.
        if (transform.position.x <= Enemy.screenBoundaryRight)
        {
            
            endPoint = true;
        }
	}
}
