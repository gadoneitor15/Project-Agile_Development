using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour {


	public float speed = 750f;
	public int speedcounter = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Text speedTekst = GameObject.FindGameObjectWithTag ("SpeedTekst").GetComponent<Text>(); 
		speedTekst.text = "Speed: " + speedcounter;

	}

	public void addForceUp(float a) {

		if(speedcounter<=9){
			Rigidbody rb = GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody> ();
			rb.AddForce (rb.velocity.normalized * a, ForceMode.Impulse);
			speedcounter++;
		}
	}

	public void addForceDown(float a) {


		if (speedcounter >= 0) {
			Rigidbody rb = GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody> ();
			rb.AddForce (rb.velocity.normalized * -a, ForceMode.Impulse);
			speedcounter--;
		}
	

	}

	public void setSpeedCounter(int a) {
		speedcounter = a;
	}

	public void setSpeed (float a) {
		speed += a;
	}

	public float getSpeed () {
		return speed;
		}
}
