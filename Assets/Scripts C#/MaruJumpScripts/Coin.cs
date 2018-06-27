using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager gameManager;
    public int coinScore;
    private int score;

    void Start()
    {
        // Fetches the GameManager class by searching for the MainCamera and extracts the GameManager.
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        coinScore = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Adds coinScore to our current score.
            gameManager.score += coinScore;

            // Removes coin.
            Destroy(this.gameObject);

            // Assigns score again, so the score doesn't stop at the score with the coinScore.
            gameManager.score = score;
        }
    }
}
