using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody rb;
    bool horizontalMovement;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        horizontalMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0.1 && rb.velocity.y > -0.1 && !horizontalMovement )
        {
            horizontalMovement = true;           
        }

        if (horizontalMovement)
        {
            rb.velocity = new Vector3(0, 20, 0);
            horizontalMovement = false;
        }

        if (transform.position.y < -11)
        {
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<BallSpawner>().shootingAmount++;
            Destroy(gameObject);

            if (GameObject.FindGameObjectWithTag("Spawner").GetComponent<BallSpawner>().shootingAmount == GameObject.FindGameObjectWithTag("Spawner").GetComponent<BallSpawner>().ballAmount)
            {
                try
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawn>().MoveBlocks();
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawn>().SpawnBlocks();
                    GameObject.FindGameObjectWithTag("Spawner").GetComponent<BallSpawner>().shootingAmount = 0;
                } catch(System.Exception)
                {

                }
            }
        }
    }
}