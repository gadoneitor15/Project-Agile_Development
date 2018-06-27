using System;
using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootScript : MonoBehaviour {
    // Use this for initialization
    void Start () {
        Screen.SetResolution(800, 1280, true);

        int firstTime = PlayerPrefs.GetInt("FirstTime");
        if (firstTime == 0)
        {
            //Run first time setup...

            Debug.Log("First time setup is running...");
            GameController.control.resetGame();
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.Save();

            StartCoroutine(nextScene.loadScene(5f, "FirstTimeStartup"));
        }
        else
        {
            //Start game normally.
            Debug.Log("Starting game...");
            StartCoroutine(nextScene.loadScene(2f, "HomeMenu Scene"));
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        Destroy(GameObject.Find("LogoPanel"));
    }
}
