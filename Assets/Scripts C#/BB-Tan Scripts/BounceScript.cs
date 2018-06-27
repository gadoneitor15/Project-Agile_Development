using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour {

    public GameObject ball;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "ball")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawn>().BlockList.Remove(this.gameObject);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawn>().bounceCount--;
        }
    }
}
