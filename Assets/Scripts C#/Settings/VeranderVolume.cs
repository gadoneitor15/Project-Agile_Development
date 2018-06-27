using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeranderVolume : MonoBehaviour {

    public Slider Volume;
    public AudioSource myMusic;

    // Volume geluid staat gelijk aan de waarde van de slider, dus als de slider 0 is, heb je geen geluid.
    void Update () {
        myMusic.volume = Volume.value;
	}
}
