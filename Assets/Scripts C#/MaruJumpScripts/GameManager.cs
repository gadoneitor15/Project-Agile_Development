using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public int score;
    public GameOver gameOver;

    public int extraValue;                        // To make the score more appealing.
    public Text scoreText;

    public Transform player;                      // Object to track is player.
    public float playerHeightY;                   // Height at which the camera will adjust to.
    public float currentCameraHeight;
    float newHeightofCamera;

    private int platNumber;                       // Used to assign specific prefabs from 1 to 3.

    private float platCheck;                      // Checks if player's height is near and spawns platforms.
    private float spawnPlatformsTo = 3f;          // Previous location platforms were spawned from. This is set at 3f so it doesn't spawn below the startPlatform.
    private int springSpawnRate = 100;            // The chance is springSpawnRate/100 that a spring will spawn on top of a regular platform.

    private float spawnCoinTo;
    private float coinCheck;
    private float enemCheck;                      // Checks if player's height is near and spawns enemies.
    private float spawnEnemyTo = 30f;             // Previous location platforms were spawned from. This is set at 3f so it doesn't spawn below the startPlatform.
   
    // Stores platform prefabs of:
    public Transform regular;
    public Transform leftRight;
    public Transform upDown;

    public Transform coin;
    public Transform enemyPrefab;

    public Transform spring;
    public Transform playScene;



	// Use this for initialization.
	void Start ()
    {
        // Finds our player gameobject using the "Player" tag.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        score = 0;

        // Finds the component text called "ScoreText"
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}

    // Update is called once per frame.
    void Update ()
    {
        extraValue = 15;
        scoreText.text = "Score: " + score * extraValue;

        // Tracks the current playerHeight y-axis.
        playerHeightY = player.position.y;

        // If the player height y-axis is greater than 0, then:
        if (playerHeightY > platCheck)
        {
            // Calls PlatformManager method.
            PlatformManager();
            EnemyManager();
            CoinManager();
        }

        // If the player's Y is higher than score.
        if (playerHeightY > score)
        {
            // The score's variable will become the playerHeight (in intergers).
            score = (int)playerHeightY;
        }

        // Tracks the current camera y-axis.
        currentCameraHeight = transform.position.y;
        // How the newHeightofCamera will adjust.
        newHeightofCamera = Mathf.Lerp(currentCameraHeight, playerHeightY, Time.deltaTime * 10);
        // Checks if playerHeightY is higher than our currentCameraHeight
        if (playerHeightY > currentCameraHeight)
        {
            // If so, the camera will be assigned a new position.
            transform.position = new Vector3(transform.position.x, newHeightofCamera, transform.position.z);
        }

        // Checks if playerHeightY is lower than the currentCameraHeight. 
        else
        {
            // If the player falls below the currentCameraHeight...
            if (playerHeightY < (currentCameraHeight - 6f))
            {
                gameOver.ShowGameOver(score * extraValue);
            }
        }

	}

    // Method for when and where to spawn platforms.
    void PlatformManager()
    {
        // Sets a value of the distance between each single platforms that spawn.
        int platformRenderDistance = 20;

        // Assigns the platCheck to our player's current y position + value.
        platCheck = player.position.y + platformRenderDistance;

        // Sends a float value at the start of (platCheck + value).
        PlatformSpawner(platCheck + platformRenderDistance);
    }

    // Method to spawn platforms.
    void PlatformSpawner(float floatValue)
    {

        // Y starts at 0, spawnPlatformsTo starts at 0, this is used as a loop.
        float y = spawnPlatformsTo;

        // while y is less or equal to floatValue.
        while (y <= floatValue)
        {
            // Variable which makes it so the platform doesn't spawn out of the left side or right side of the screen.
            float x = Random.Range(Wrap.screenLeft, Wrap.screenRight);

            // Variable which makes it so the platform can vary from regular, leftRight or upDown.
            platNumber = Random.Range(1, 4);

            // Combine our x and y values to creat a Vector2.
            Vector2 posXY = new Vector2(x, y);

            // Use the platNumber randomly picked, to spawn a specific platform.
            // In this case we use a switch because it is faster than an if/else statement
            switch (platNumber)
            {
                case 1:
                    Instantiate(regular, posXY, Quaternion.identity, playScene);           // regular platform.
                    // Gives a randomised number between springSpawnRate and 100.
                    int chance = Random.Range(0, 200);
                    // Spawns a spring
                    if (chance < springSpawnRate) Instantiate(spring, (posXY + new Vector2(0, 0.34f)), Quaternion.identity, playScene);       
                    break;
                case 2:
                    Instantiate(leftRight, posXY, Quaternion.identity, playScene);         // leftRight platform.
                    break;
                case 3:
                    Instantiate(upDown, posXY, Quaternion.identity, playScene);            // upDown platform.
                    break;
            }

            // Everytime Y is less or equal to floatValue. It runs and adds the following floats to the Y value.
            y += Random.Range(.5f, 1.75f);
        }
        
        // Reassigns spawnpoint to the floatValue so platforms are not spawned below an already spawned area.
        spawnPlatformsTo = floatValue;
    }

    // Method for where and when to spawn enemies.
    void EnemyManager()
    {
        int enemyRenderDistance = 2;

        enemCheck = player.position.y + enemyRenderDistance;

        EnemySpawner(enemCheck + enemyRenderDistance);
    }

    // Method for where and when to spawn coins.
    void CoinManager()
    {
        int coinRenderDistance = 2;

        coinCheck = player.position.y + coinRenderDistance;

        coinSpawner(coinCheck + coinRenderDistance);
    }

    // Method to spawn enemies.
    void EnemySpawner(float floatValue)
    {

        // Y starts at 0, spawnEnemyto starts at 0, this is used as a loop.
        float y = spawnEnemyTo;

        // Variable which makes it so the enemy doesn't spawn out of the left side or right side of the screen.
        float x = Random.Range(Wrap.screenLeft, Wrap.screenRight);

        // Combine our x and y values to creat a Vector2.
        Vector2 posXY = new Vector2(x, y + 25);

        Instantiate(enemyPrefab, posXY, Quaternion.identity, playScene);

        // Everytime Y is less or equal to floatValue. It runs and adds the following floats to the Y value.
        y += Random.Range(1f, 1.3f);

        // Reassigns spawnpoint to the floatValue so enemies are not spawned below an already spawned area.
        spawnEnemyTo = floatValue;
   
    }

    void coinSpawner (float floatValue)
    {

        float y = spawnCoinTo;
        float x = Random.Range(Wrap.screenLeft, Wrap.screenRight);

        Vector2 posXY = new Vector2(x,y + 25);

        Instantiate(coin, posXY, Quaternion.identity, playScene);
        y += Random.Range(1, 2);

        spawnCoinTo = floatValue;


    }
}