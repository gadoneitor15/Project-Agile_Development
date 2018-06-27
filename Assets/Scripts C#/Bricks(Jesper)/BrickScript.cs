using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


	public class BrickScript : MonoBehaviour {

	int aantalBricks = 0;
	int aantalLives = 3;
	public GameObject BrickPreFab;
	public GameObject Brick2PreFab;
	public GameObject Brick3PreFab;
	public GameObject Brick4PreFab;
	public GameObject Brick5PreFab;
	float Minx = -7.5f;
	float Miny = -5f;
	float Maxx = 7.5f;
	public int score;
	float Maxy = 10f;
	List<GameObject> prefabList = new List<GameObject>();


	// Use this for initialization
	void Start () {
		


		CreateBrick ();
		Brick2PreFab.AddComponent (typeof(Hitpoints));
		Brick2PreFab.GetComponent<Hitpoints> ().hitpoints = 2;
		BrickPreFab.AddComponent (typeof(Hitpoints));
		BrickPreFab.GetComponent<Hitpoints> ().hitpoints = 1;
		Brick3PreFab.AddComponent (typeof(Hitpoints));
		Brick3PreFab.GetComponent<Hitpoints> ().hitpoints = 3;
		Brick4PreFab.AddComponent (typeof(Hitpoints));
		Brick4PreFab.GetComponent<Hitpoints> ().hitpoints = 4;
		Brick5PreFab.AddComponent (typeof(Hitpoints));
		Brick5PreFab.GetComponent<Hitpoints> ().hitpoints = 5;




	}


	// Update is called once per frame
	void Update () {

		Text scoreText = GameObject.FindGameObjectWithTag ("Score").GetComponent<Text>(); 
		scoreText.text = "Score: " + score;

		Text brick = GameObject.FindGameObjectWithTag ("Aantal").GetComponent<Text>(); 
		brick.text = "Aantal: " + aantalBricks;

		Text lives = GameObject.FindGameObjectWithTag ("LivesText").GetComponent<Text>(); 
		lives.text = "Lives: " + aantalLives;

		if (aantalBricks == 0) {
			LevelControllerScript ls = GameObject.Find ("LevelController").GetComponent<LevelControllerScript> ();
			ls.setLevel (1);
			BallScript bs = GameObject.FindGameObjectWithTag ("Ball").GetComponent<BallScript> ();
			bs.Die ();

			CreateBrick ();
		}


	}



	public void setAantalBricks (int a){
		aantalBricks += a;
	}

	public void setAantalLives (int a){
		aantalLives += a;
	}

	public int getAantalLives() {
		return aantalLives;
	}

	void CreateBrick(){

		int level = GameObject.Find ("LevelController").GetComponent<LevelControllerScript> ().getLevel();
		prefabList.Add(BrickPreFab);
		prefabList.Add(Brick2PreFab);
		prefabList.Add(Brick3PreFab);
		prefabList.Add(Brick4PreFab);
		prefabList.Add(Brick5PreFab);

	

		for (int i = 0; i < level; i++) {
			
			int prefabIndex = 0;

			if (level >= 4 && level <= 7) {
				prefabIndex = Random.Range (0, 2);
			} 
			else if (level >= 8 && level <= 11) {
				prefabIndex = Random.Range (0, 3);
			} 
			else if (level >= 9 && level <= 13) {
				prefabIndex = Random.Range (0, 4);
			} 
			else if (level >= 14) {
				prefabIndex = Random.Range (0, 5);
			} 

			float x = Random.Range (Minx, Maxx);
			float y = Random.Range (Miny, Maxy);
			var newPosition = new Vector3 (x,y,0);

			if (!Physics.CheckBox(newPosition,new Vector3(1.5f,0.75f,0))){
				Instantiate (prefabList[prefabIndex], new Vector3 (x, y, 0), Quaternion.identity);
				aantalBricks++;
			} else {
				i--;
			}
			
		}

		}
	}
