using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float movementSpeed = 4f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int scorePlayer;
    public GameManager gameManager;
    GameObject bullet;
    bool rotator;
    Rigidbody2D dog;

    void Start()
    {
        rotator = false;
        scorePlayer = 0;
        dog = GetComponent<Rigidbody2D>();

        // Fetches the GameManager class by searching for the MainCamera and extracts the GameManager.
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        // Allows user to move with A/D or Left/Right keys.
        float horizontal = Input.GetAxis("Horizontal");

        dog.velocity = new Vector2(horizontal * movementSpeed, dog.velocity.y);

        if (Input.GetAxis("Horizontal") > 0) rotator = true; // gets right
        //if (Input.GetAxis("Horizontal") < 0) rotator = false; // gets leftdog.rotation += 3;

        if (rotator)
            // dog.rotation -= 3;
            //  else 
            dog.rotation += 3;

        // If space is pressed...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Bullets will be spawn.
            Fire(dog.position);
        }
    }

    void Fire(Vector2 dogPosition)
    {
            // Create the bullet from the bulletPrefab.
            bullet = Instantiate(bulletPrefab, dogPosition + new Vector2(0, 1), bulletSpawn.rotation, gameManager.playScene);

            // Adds velocity to the bullet.
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;

            // Destroy the bullet after 2 seconds.
            Destroy(bullet, 2.0f);

    }
}
