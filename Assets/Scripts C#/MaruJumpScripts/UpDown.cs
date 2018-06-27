using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour {

    float platformSpeed = 2f;
    bool endPoint;

    float startPoint;
    float endPointY;

    public int unitsToMove = 2;

    // Use this for initialization.
    void Start()
    {
        startPoint = transform.position.y;
        endPointY = startPoint + unitsToMove;
    }

    // Update is called once per frame.
    void Update ()
    {
        // Checks if endPoint is true.
        if (endPoint)
        {
            // If so, then adds Vector3.up * platformSpeed * Time.deltaTime to the transform.Position.
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
        }	
        else
        {
            // Else it substracts Vector3.up * platformSpeed * Time.deltaTime from the transform.Position.
            transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
        }

        // Checks whether the transform.position.y is INSIDE of boundary of the endPointY.
        if (transform.position.y >= endPointY)
        {
           
            endPoint = false;
        }

        // Checks whether+ the transform.position.x is INSIDE of boundary of startPoint.
        if (transform.position.y <= startPoint)
        {
            
            endPoint = true;
        }
	}
}
