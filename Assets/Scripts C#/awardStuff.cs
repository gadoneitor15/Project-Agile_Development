using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awardStuff : MonoBehaviour {

    public GameObject MaruJump, Snake, BBtan;

	public void awardCurrency(int balance)
    {
        GameController.control.PlayerData.Balance += balance;
        GameController.control.PlayerData.saveData();
    }
    public static void awardSCurrency(int balance)
    {
        GameController.control.PlayerData.Balance += balance;
        GameController.control.PlayerData.saveData();
    }

    public void awardExperience(int experience)
    {
        GameController.control.PlayerData.Experience += experience;
        if (GameController.control.PlayerData.Experience >= GameController.control.PlayerData.ExperienceNeeded)
        {
            GameController.control.PlayerData.Level++;
            //GameController.control.PlayerData.Experience -= GameController.control.PlayerData.ExperienceNeeded;
            GameController.control.PlayerData.ExperienceNeeded *= 2;
        }

        GameController.control.PlayerData.saveData();
    }
    public static void awardSExperience(int experience)
    {
        GameController.control.PlayerData.Experience += experience;
        if (GameController.control.PlayerData.Experience >= GameController.control.PlayerData.ExperienceNeeded)
        {
            GameController.control.PlayerData.Level++;
            //GameController.control.PlayerData.Experience -= GameController.control.PlayerData.ExperienceNeeded;
            GameController.control.PlayerData.ExperienceNeeded *= 2.5;
        }

        GameController.control.PlayerData.saveData();
    }
}
