using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {


	Color blue = new Color(0,0,255);
	Color red = new Color(255,0,0);
	Color white = new Color(255,255,255);
	Color green = new Color(0,255,0);
	Color purple = new Color(255,0,255);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Die () {
		
		Destroy (GameObject.FindGameObjectWithTag("Ball").gameObject);

		PaddleScript ps = GameObject.Find ("Paddle").GetComponent<PaddleScript> ();
		ps.SpawnBall ();
	

		}

	


	public void DieForReal() {

		BrickScript bs =GameObject.Find("BrickController").GetComponent<BrickScript> ();
		bs.setAantalLives (-1);

		int aantalLives = bs.getAantalLives ();

		if (aantalLives == 0) {
            awardStuff.awardSCurrency(Mathf.FloorToInt(bs.score/10));
            awardStuff.awardSExperience(Mathf.FloorToInt(bs.score / 20));
			SceneManager.LoadScene ("BricksGameOver");
		}
	}


	public void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Brick") {
			

			col.gameObject.GetComponent<Hitpoints> ().hitpoints--;

			if (col.gameObject.GetComponent<Hitpoints> ().hitpoints== 5) {
				col.gameObject.GetComponent<Renderer> ().material.color = purple;
				GameObject.Find ("BrickController").GetComponent<BrickScript> ().score++;
			}
			if (col.gameObject.GetComponent<Hitpoints> ().hitpoints== 4) {
				col.gameObject.GetComponent<Renderer> ().material.color = green;
				GameObject.Find ("BrickController").GetComponent<BrickScript> ().score++;
			}
			if (col.gameObject.GetComponent<Hitpoints> ().hitpoints== 3) {
				col.gameObject.GetComponent<Renderer> ().material.color = white;
				GameObject.Find ("BrickController").GetComponent<BrickScript> ().score++;
			}
			if (col.gameObject.GetComponent<Hitpoints> ().hitpoints== 2) {
				col.gameObject.GetComponent<Renderer> ().material.color = blue;
				GameObject.Find ("BrickController").GetComponent<BrickScript> ().score++;
			}
			if (col.gameObject.GetComponent<Hitpoints> ().hitpoints== 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = red;
				GameObject.Find ("BrickController").GetComponent<BrickScript> ().score++;
			}

			if(col.gameObject.GetComponent<Hitpoints> ().hitpoints==0) {
				GameObject.Find ("BrickController").GetComponent<BrickScript> ().score++;
			Destroy (col.gameObject);

			GameObject.Find ("BrickController").GetComponent<BrickScript> ().setAantalBricks (-1);

			}
		}


	}
}
