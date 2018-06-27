using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    bool spawnBlocks;
    List<GameObject> blocks;
    public static GameObject bounce;
    public GameObject plusOne;
    public GameObject weakBrick;
    public GameObject strongBrick;
    public Transform[] spawnPoints;
    float random;

    public int score = 0;

    public GameObject BallspawnerObject;
    public BBtanGameOver gameoverScript;

    int hitCounter = 0;

    public int bounceCount;
    public int plusOneCount;

    public BallSpawner BallSpawner;

    public static int rowNumber = 1;

    // Use this for initialization
    void Start()
    {
        SpawnBlocks();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnBlocks()
    {
        blocks = new List<GameObject>();
        for (int i = 0; i < 7; i++)
        {
            random = Random.Range(0, 100);
            if (random > 0 && random < 39)
            {
                GameObject redBrick = Instantiate(weakBrick, spawnPoints[i].position, Quaternion.identity);
                blocks.Add(redBrick);
            }

            if(random > 40 && random < 49)
            {
                GameObject blueBrick = Instantiate(strongBrick, spawnPoints[i].position, Quaternion.identity);
                blocks.Add(blueBrick);
                bounceCount++;
            }

            if (random > 50 && random < 54 && bounceCount < 1)
            {
                GameObject Bouncer = Instantiate(bounce, spawnPoints[i].position, Quaternion.identity);
                blocks.Add(Bouncer);
                bounceCount++;
            }

            if (random > 55 && random <= 100 && plusOneCount < 1)
            {
                GameObject PlusOne = Instantiate(plusOne, spawnPoints[i].position, Quaternion.identity);
                blocks.Add(PlusOne);
                plusOneCount++;
            }
        }
        rowNumber++;
        plusOneCount--;
    }

    public List<GameObject> BlockList
    {
        get
        {
            return blocks;
        }
    }


    public void MoveBlocks()
    {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("WeakBlock"))
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - 1.5f, o.transform.position.z);
                if(o.transform.position.y <= BallspawnerObject.GetComponent<Transform>().position.y)
            {
                gameoverScript.ShowGameOver(score);
            }
            }

        foreach (GameObject o in GameObject.FindGameObjectsWithTag("StrongBlock"))
        {
            o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - 1.5f, o.transform.position.z);
        }

        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Bounce"))
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - 1.5f, o.transform.position.z);
            if (o.transform.position.y <= BallspawnerObject.GetComponent<Transform>().position.y)
            {
                gameoverScript.ShowGameOver(score);
            }
        }

            foreach (GameObject o in GameObject.FindGameObjectsWithTag("PlusOne"))
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - 1.5f, o.transform.position.z);
            }
        BallSpawner.isMoving = false;
        {

        }
    }

}
