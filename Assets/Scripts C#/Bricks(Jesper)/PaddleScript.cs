using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class PaddleScript : MonoBehaviour {

	public GameObject BallPreFab;

	GameObject attachedBall = null;
	Rigidbody ballRigidbody;

	float paddleSpeed = 15f;
	int score = 0;
	float speed = 0.03f;


	void Start () {

        gameObject.GetComponent<Renderer>().material.color = GameController.control.PlayerData.PaddleColor;
		SpawnBall ();
	}

	void Update () {

		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;

		}
	
	


		//movement keyboard
		transform.Translate (paddleSpeed * Time.deltaTime*Input.GetAxis ("Horizontal"), 0, 0);

        //movement touch
        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);


            // If the finger is on the screen, move the object smoothly to the touch position
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            transform.position = Vector3.Lerp(transform.position, new Vector3(touchPosition.x, -11.8f, 0), 0.5f);

        }

        //paddle inside bounderies
        if (transform.position.x > 8f) {
			transform.position = new Vector3 (8f, transform.position.y, transform.position.z);
		} else if (transform.position.x < -8f) {
			transform.position = new Vector3 (-8f, transform.position.y, transform.position.z);
		}
			
		float ballSpeed = GameObject.FindGameObjectWithTag("speed").GetComponent<SpeedScript> ().getSpeed ();

		if (attachedBall) {
			ballRigidbody = attachedBall.GetComponent<Rigidbody> ();
			ballRigidbody.position = transform.position + new Vector3 (0, 0.75f, 0);

			if (Input.GetButtonDown("Jump")){
				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce(0,ballSpeed,0);
				attachedBall = null;
			}		

			if(fingerCount ==2){


				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce(0,ballSpeed,0);
				attachedBall = null;
			}
		
		}
	}

		
	

	public void SpawnBall() {

		attachedBall = (GameObject)Instantiate (BallPreFab, transform.position +new Vector3 (0, 40, 0), Quaternion.identity);
		attachedBall.tag = "Ball";
		GameObject.FindGameObjectWithTag ("speed").GetComponent<SpeedScript> ().setSpeedCounter(1);

	}

	void OnCollisionEnter (Collision col) {

		foreach (ContactPoint contact in col.contacts) {
			if (contact.thisCollider == GetComponent<Collider>()) {
				float ballAngle = contact.point.x - transform.position.x;
				contact.otherCollider.GetComponent<Rigidbody> ().AddForce (100f * (2*ballAngle), 0, 0);
			}
		}

	}	
}