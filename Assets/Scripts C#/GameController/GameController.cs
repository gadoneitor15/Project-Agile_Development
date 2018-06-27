using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController control;
    PlayerData playerData;
    GUIContent layoutContent;
    GUIStyle layoutStyle;

	public PlayerData PlayerData {
		get {
			return playerData;
		}
	}

    private void Start()
    {
        layoutContent = new GUIContent();
        layoutStyle = new GUIStyle();

        layoutContent.text = "";
        layoutStyle.fontSize = 28;
        layoutStyle.fontStyle = FontStyle.Bold;
        layoutStyle.alignment = TextAnchor.UpperCenter;


        
    }

    private void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
			playerData = new PlayerData ();
            playerData.loadData();
        }
        else if(control != this)
        {
			//playerData.saveData ();
            Destroy(gameObject);
        }
	}

    private void OnGUI()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HomeMenu Scene"))
        {
            string balance = playerData.Balance.ToString();

            string time = "";
            if (DateTime.Now.Hour < 10)
            {
                time += "0";
            }
            time += DateTime.Now.Hour + ":";
            if (DateTime.Now.Minute < 10)
            {
                time += "0";
            }
            time += DateTime.Now.Minute;

            layoutContent.text = "Level: " + playerData.Level + "\t\tTime: " + time + "\t\t" + balance;
            GUI.Label(new Rect(0, 40, Screen.width, 100), layoutContent, layoutStyle);

            layoutContent.text = "Exp: " + playerData.Experience + "/" + playerData.ExperienceNeeded;
            GUI.Label(new Rect(0, 65, Screen.width, 100), layoutContent, layoutStyle);
        }
    }

    public void resetGame()
    {
        PlayerPrefs.DeleteAll();
        this.playerData.Balance = 0;
        this.PlayerData.Level = 1;
        this.PlayerData.Experience = 0;
        this.PlayerData.ExperienceNeeded = 100;
        this.playerData.Time = DateTime.Now;
        this.playerData.ShopInventory = null;
        this.playerData.MaruJumpHighScore = 0;
        this.playerData.BBtanHighscore = 0;
        this.playerData.SnakeHighscore = 0;
        this.playerData.PaddleColor = Color.white;
        this.playerData.SnakeColor = Color.white;
        this.playerData.AppleColor = Color.white;
        this.playerData.BBtanBallColor = Color.white;
        try
        {
            this.playerData.Achievements.Clear();
        }
        catch (Exception) { }
        this.playerData.saveData();

    }
}