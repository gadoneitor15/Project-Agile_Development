using UnityEngine;
using UnityEngine.UI;

public class SnakeGameOver : MonoBehaviour
{
    public awardStuff award;
    public GameObject Canvas;
    public Text Highscore;
    public Text Score;

    public void ShowGameOver(int score)
    {
        Score.text = score.ToString();

        int highscore = GameController.control.PlayerData.SnakeHighscore;
        if(score > highscore)
        {
            highscore = score;
            GameController.control.PlayerData.SnakeHighscore = highscore;
            GameController.control.PlayerData.saveData();
        }
        Highscore.text = highscore.ToString();

        calcBalance(score);
        calcExperience(score);
            
        Canvas.SetActive(true);
    }

    private void calcBalance(int score)
    {
        award.awardCurrency(Mathf.FloorToInt(score / 10));
    }
    private void calcExperience(int score)
    {
        award.awardExperience(Mathf.FloorToInt(score / 20));
    }
}
