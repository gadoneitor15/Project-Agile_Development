using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DirectionBall : MonoBehaviour {

    public GameObject ball;
    Ball ballScript;
    float rotation;

	// Use this for initialization
	void Start () {
        ballScript = ball.GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {


        transform.position = ball.transform.position;
        
        rotation = Mathf.Atan(ballScript.direction.x / ballScript.direction.y);
        rotation *= -Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0,rotation);
        
    }
}
