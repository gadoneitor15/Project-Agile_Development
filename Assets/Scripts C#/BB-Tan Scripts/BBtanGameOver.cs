using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BBtanGameOver : MonoBehaviour {

    public awardStuff award;
    public GameObject Canvas, mainCanvas;
    public Text Highscore;
    public Text Score;
	
    public void ShowGameOver(int score)
    {
        Score.text = score.ToString();

        int highscore = GameController.control.PlayerData.BBtanHighscore;
        if(score > highscore)
        {
            highscore = score;
            GameController.control.PlayerData.BBtanHighscore = highscore;
            GameController.control.PlayerData.saveData();
        }

        Highscore.text = highscore.ToString();
        calcBalance(score);

        mainCanvas.SetActive(false);
        Canvas.SetActive(true);
    }

    private void calcBalance(int score)
    {
        award.awardCurrency(Mathf.FloorToInt(score / 100));
        award.awardExperience(Mathf.FloorToInt(score / 200));
    }
}
