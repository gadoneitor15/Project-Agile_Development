using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

    public awardStuff award;
    public GameObject GameOverScreen;
    public GameObject PlayScreen;
    public Text Highscore;
    public Text Score;
    public int value;

    public void ShowGameOver(int score)
    {
        Score.text = "Your Score: " + score.ToString();

        // Makes it so you can access the playerData.MaruJumpHighScore.
        int highscore = GameController.control.PlayerData.MaruJumpHighScore;

        // If the achieved score is higher than the current highscore...
        if (score > highscore)
        {
            // Then this score will be the new highscore.
            highscore = score;
            // Saves the highscore.
            GameController.control.PlayerData.MaruJumpHighScore = highscore;
            GameController.control.PlayerData.saveData();
        }
        Highscore.text = "Highscore: " + highscore.ToString();

        // The methods "calBalance" and "calcExperience" will be called here.
        calcBalance(score);
        calcExperience(score);

        // The game over screen will be shown.
        GameOverScreen.SetActive(true);
        PlayScreen.SetActive(false);
    }

    // This method calculates how much gold you earn through scoring.
    private void calcBalance(int score)
    {
        award.awardCurrency(Mathf.FloorToInt(score / 50));
    }

    // This method calculates how much experience you earn through scoring.
    private void calcExperience(int score)
    {
        award.awardExperience(Mathf.FloorToInt(score / 50));
    }
}
