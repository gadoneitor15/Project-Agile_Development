using UnityEngine;


public class Enemy : MonoBehaviour
{

    float platformSpeed = 2f;
    bool endPoint;

    public static float screenBoundaryLeft = 2.9f;               // Boundary left side of the screen.
    public static float screenBoundaryRight = -2.9f;             // Boundary right side of the screen.

    private int score;
    private int enemyScore;
    private int enemyHealth;

    GameManager gameManager;

    void Start()
    {
        // Fetches the GameManager class by searching for the MainCamera and extracts the GameManager.
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();

        // Fetches the score from the GameManager.
        enemyHealth = 2;                // Enemy has 2 lives.
        enemyScore = 20;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Uses a GameOver function which has been received by using GameManager
            gameManager.gameOver.ShowGameOver(gameManager.score * gameManager.extraValue);          
        }

        if (collision.gameObject.tag == "Bullet")
        {
            // Uses a GameOver function which has been received by using GameManager
            gameManager.score += enemyScore;

            // Substracts one of the enemyHealth.
            enemyHealth -= 1;

            // If enemyHealth reaches 0...
            if (enemyHealth == 0)
            {
                // Destroys the enemy.
                Destroy(this.gameObject);
            }

            // Destroys bullet as well.
            Destroy(collision.gameObject);

            // Assigns score again, so the score doesn't stop at the score with the enemyScore.
            gameManager.score = score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if endPoint is true.
        if (endPoint)
        {
            // If so, then adds Vector3.right * platformSpeed * Time.deltaTime to the transform.Position.
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }
        else
        {
            // Else it substracts Vector3.right * platformSpeed * Time.deltaTime from the transform.Position.
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

        // Checks if the transform.position.x is INSIDE of boundary of the left side of the screen.
        if (transform.position.x >= screenBoundaryLeft)
        {

            endPoint = false;
        }

        // Checks if the transform.position.x is INSIDE of boundary of the right side of the screen.
        if (transform.position.x <= screenBoundaryRight)
        {

            endPoint = true;
        }
    }
}
