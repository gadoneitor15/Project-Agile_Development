/*
 * Achievement.cs
 * Handles the states of the achievements
 * and rewards them upon completion
 * of the amount of time not smoking.
 */

using UnityEngine;
using System;

[Serializable]
public class Achievement {

	private bool unlocked;
	private int unlockTime;

	[SerializeField]
	private string name;
    private string message;
    private int balance;
	private int exp;
	private DateTime currentDate;

	//Achievement constructor
	public Achievement(string name, string message, int balance, int exp, int unlockTime) {
		this.name = name;
		this.message = message;
		this.unlockTime = unlockTime;
		this.unlocked = false;
		this.balance = balance;
		this.exp = exp;
    }

	//Checks wether the achievement requirement is met
	//and awards the player with money and reward, sets
	//the achievement on unlocked and saves it to the player's data.
	public void Update() {
		currentDate = DateTime.Now;
		if (TimeNotSmoked() <= 0 && !unlocked) {
			unlocked = true;
			GameController.control.PlayerData.Balance += balance;
            GameController.control.PlayerData.Experience += exp;
            GameController.control.PlayerData.saveData();
		}
	}

    public string Message {
        get {
            return message;
        }
    }

    public int Balance {
        get {
            return balance;
        }
    }

	public int Experience {
		get {
			return exp;
		}
	}

	public string Name {
		get {
			return name;
		}
	}


	public bool Unlocked {
		get {
			return unlocked;
		}
        set
        {
            unlocked = value;
        }
	}

	//A simple method to check wether the the last
	//time the user hasn't smoked and the current time
	//taken from the system.
	private int TimeNotSmoked() {
		TimeSpan span = currentDate.Subtract(GameController.control.PlayerData.Time);
		return unlockTime - (int) span.TotalSeconds;
	}

}