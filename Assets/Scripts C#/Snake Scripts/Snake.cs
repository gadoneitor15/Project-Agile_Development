using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    public SnakeGameOver GameOver;
    public GameObject HeadSprite;

    private SpawnFood foodSpawner;

    private int score;

    // Een lijst voor het lichaam en een lijst voor de muur
    List<Transform> tail = new List<Transform>();

    // Controleert of de snake iets heeft gegeten
    bool ate = false;

    // Lichaam Prefab
    public GameObject lichaamPrefab;
    
    // Geeft de richting van de beweging aan, snake gaat automatisch naar beneden bij begin
    Vector2 dir = Vector2.down;
    Vector2 moveVector;

    // Deze snelheid aanpassen als je verschillende snelheden wilt vrijkopen?
    [SerializeField]
    private float snelheid = 0.5f;

    // Use this for initialization
    void Start()
    {
        HeadSprite.GetComponent<SpriteRenderer>().color = GameController.control.PlayerData.SnakeColor;
        lichaamPrefab.GetComponent<SpriteRenderer>().color = GameController.control.PlayerData.SnakeColor;

        foodSpawner = GetComponent<SpawnFood>();
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, snelheid);
    }

    public enum SwipeDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    public static SwipeDirection Swipe;
    private bool swiping = false;
    private bool eventSent = false;
    private Vector2 lastPosition;


    void Update()
    {

        if (Input.touchCount != 0)
        {

            if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
            {
                if (swiping == false)
                {
                    swiping = true;
                    lastPosition = Input.GetTouch(0).position;
                    return;
                }
                else
                {
                    if (!eventSent && Swipe != null)
                    {
                        Vector2 direction = Input.GetTouch(0).position - lastPosition;

                        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        {
                            if (direction.x > 0)
                                Swipe = SwipeDirection.Right;
                            else
                                Swipe = SwipeDirection.Left;
                        }
                        else
                        {
                            if (direction.y > 0)
                                Swipe = SwipeDirection.Up;
                            else
                                Swipe = SwipeDirection.Down;
                        }

                        eventSent = true;
                    }
                }
            }
            else
            {
                swiping = false;
                eventSent = false;
            }
        }

        if ((Swipe == SwipeDirection.Up) && (dir != Vector2.down))
        {
            //Up
            dir = Vector2.up;

            HeadSprite.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (Swipe == SwipeDirection.Down && (dir != Vector2.up))
        {
            //Down
            dir = Vector2.down;

            HeadSprite.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (Swipe == SwipeDirection.Left && (dir != Vector2.right))
        {
            //Left
            dir = Vector2.left;

            HeadSprite.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Swipe == SwipeDirection.Right && (dir != Vector2.left))
        {
            //Right
            dir = Vector2.right;

            HeadSprite.transform.eulerAngles = new Vector3(0, 0, 270);
        }

        // TOT HIER COMENTEN VOOR LAPTOP ENZO, HIERBOVEN IS VOOR TELEFOON, SWIPEN

        // Dit is voor de besturing van snake op de LAPTOP: links, rechts, naar beneden en naar boven
        // if-statement (dir != -Vector2.right) etc zorgt ervoor dat je niet naar de tegenovergestelde richting kan gaan
        //if (Input.GetKey(KeyCode.UpArrow) && (dir != Vector2.down))
        //{
        //    //Up
        //    dir = Vector2.up;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow) && (dir != Vector2.up))
        //{
        //    //Down
        //    dir = Vector2.down;
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow) && (dir != Vector2.right))
        //{
        //    //Left
        //    dir = Vector2.left;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) && (dir != Vector2.left))
        //{
        //    //Right
        //    dir = Vector2.right;
        //}
    }

    void Move()
    {
        // Uitvoeren als snake appel gegeten heeft
        if (ate)
        {
            // Reset the flag
            ate = false;

            // Load Prefab into the world
            GameObject g = Instantiate(lichaamPrefab, transform.position, Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            score++;
        }

        else if (tail.Count > 0) // Do we have a Tail?
        {
            // move the last tile to the head's position 
            tail[tail.Count - 1].transform.localPosition = transform.localPosition;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }

        // Move head into new direction
        transform.Translate(dir * 0.2f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.tag.Equals("Snake_Food"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);

            // Nieuw voedsels
            foodSpawner.Spawn();
        }
        else if (coll.tag.Equals("Snake_Wall") || coll.tag.Equals("Snake_Body"))
        {
            if (tail.Count > 0 && coll.gameObject == tail[0].gameObject)
            {
                return;
            }
            CancelInvoke("Move");

            GameOver.ShowGameOver(score);
        }
    }
}