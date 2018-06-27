using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInput : MonoBehaviour {

    public InputField Gebruikersnaam;
    private string name;

	// Use this for initialization
	void Start () {
        name = GameObject.Find("Gebruikersnaam").GetComponent<InputField>().text;
        Debug.Log(name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

