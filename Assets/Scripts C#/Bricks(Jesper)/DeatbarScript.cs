using UnityEngine;
using System.Collections;

public class DeatbarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		BallScript bs = other.GetComponent<BallScript> ();


		if (bs) {
			bs.Die ();
			bs.DieForReal ();
		}
	}
}
