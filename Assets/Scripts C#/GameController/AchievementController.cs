/*
 * AchievementController.cs
 * Handles the achievements within the game
 * and displays the states wether the user
 * has earned the achievement.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AchievementController : MonoBehaviour {

	[SerializeField]
	private GameObject unlocked;

	[SerializeField]
	private GameObject locked;

	[SerializeField]
	private List<Achievement> achievements = new List<Achievement> ();

    void Start () {
		//Checks wether there are achievements in the save file.
		if (GameController.control.PlayerData.Achievements == null || GameController.control.PlayerData.Achievements.Count == 0) {

			//Adds the achievements to the player's save file 
			//in a locked state which the player can earn.

			achievements.Add (new Achievement ("BEGIN", "Gefeliciteerd, u maakt nu een start om te stoppen met roken!", 0, 0, 0));
            achievements.Add (new Achievement ("20 minuten", "Uw bloeddruk daalt tot normaal niveau!", 25, 20, 20 * 60));
			achievements.Add (new Achievement ("2 uur", "Nicotinebehoefte speelt op, honger, onrust, cravings... Dat komt omdat je goed bezig bent!", 50, 40, 2 * 60 * 60));
			achievements.Add (new Achievement ("8 uur", "Koolstofmonoxide neemt af, zuurstofgehalte in het bloed neemt toe!", 100, 75, 8 * 60 * 60));
			achievements.Add (new Achievement ("24 uur", "Geen spoor meer van koolstofmoxide (hoesten is mogelijk door vuil afstoot)!", 200, 100, 24 * 60 * 60));
			achievements.Add (new Achievement ("48 uur", "Alle nicotine is uit het lichaam verdwenen, je bent niet lichamelijk meer verslaafd + je hebt een beter reukvermogen!", 300, 150, 48 * 60 * 60));
			achievements.Add (new Achievement ("72 uur", "Uw kunt eenvoudiger adem halen en wordt energieker!", 400, 200, 72 * 60 * 60));
			achievements.Add (new Achievement ("1 week", "Mogelijke ontwenningsverschijnselen: keelpijn, hoofdpijn...", 500, 250, 168 * 60 * 60));
			achievements.Add (new Achievement ("2 weken", "U bent al twee weken rook-vrij, ga zo door!", 750, 375, 2 * 168 * 60 * 60));
			achievements.Add (new Achievement ("3 weken", "Al 3 weken niet meer gerookt!", 1000, 500, 3 * 168 * 60 * 60));
			achievements.Add (new Achievement ("1 maand", "Longfunctie is aanzienlijk verbeterd!", 1500, 750, 2629743));
			achievements.Add (new Achievement ("3 maanden", "Uw longfunctie is met 10% verbeterd, u wordt minder snel verkouden.", 2500, 1250, 3 * 2629743));
			achievements.Add (new Achievement ("5 maanden", "Maar liefst 5 maanden niet gerookt!", 5000, 2500, 5 * 2629743));
			achievements.Add (new Achievement ("1 jaar", "U heeft al 1 jaar niet meer gerookt, FANTASTISCH!", 10000, 5000, 31556926));
		} else {
			//Fetches the achievements from the player's save file and puts them in a list.
			achievements = GameController.control.PlayerData.Achievements;
		}
		SpawnAchievements();
	}

	void OnDestroy() {
		//If you switch scenes, all data from the achievements will be saved.
		GameController.control.PlayerData.Achievements = achievements;
	}

	//Converts the player's save file into displayable achievements.
    private void SpawnAchievements() {

		//Searches the achievement grid from the scene to place all achievements.
		Transform parent = GameObject.Find ("AchievementsGrid").transform;

        foreach (Achievement achievement in achievements) {
			//Checks wether the time requirement is earned from Achievement.cs
			achievement.Update();

			//If the achievement is unlocked, you will see the smoker's quote 
			//and the rewards you earned from that achievement.
			if (achievement.Unlocked) {
				//Uses the prefab "Unlocked" from the scene which 
				//shows the rewards you earned from an achievement.
				GameObject achievementAward = Instantiate (unlocked, parent) as GameObject;
				Button button = achievementAward.GetComponent<Button> ();
				button.GetComponentsInChildren<Text>()[0].text = achievement.Name;
				button.GetComponentsInChildren<Text>()[1].text = achievement.Message;

				string reward = "Rewards: Gold x " + achievement.Balance + ", EXP x " + achievement.Experience;
				button.GetComponentsInChildren<Text>()[2].text = reward;
			} else {
				//Uses the prefab "Locked" from the scene which 
				//only shows the name of the achievement.
				GameObject achievementAward = Instantiate (locked, parent) as GameObject;
				Button button = achievementAward.GetComponent<Button> ();
				button.GetComponentsInChildren<Text>()[0].text = achievement.Name;
			}
        }
    }
}