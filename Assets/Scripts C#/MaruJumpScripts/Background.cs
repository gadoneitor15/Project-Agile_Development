using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private GameManager gameManager;
    public static Background instance;
    public float scrollSpeed = -1.5f;

    // Use this for initialization.
    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();

        //Start the object moving.
        rb2d.position = new Vector2(0, gameManager.playerHeightY);
    }
}
