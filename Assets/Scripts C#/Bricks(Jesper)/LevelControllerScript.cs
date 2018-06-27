using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelControllerScript : MonoBehaviour {


	int level = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Text levelTekst = GameObject.FindGameObjectWithTag ("Level").GetComponent<Text> ();
		levelTekst.text = "Level: " + level;
	}

	public void setLevel (int a) {
		level +=a;
	}

	public int getLevel () {
		return level;
	}

}
