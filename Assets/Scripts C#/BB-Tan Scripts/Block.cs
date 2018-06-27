using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public GameObject ball;

    int ballHits = Spawn.rowNumber;

    public int weakBallHits;

    public int strongBallHits;

    public int score = 1;

    

    // Use this for initialization
    void Start()
    {
       weakBallHits = ballHits;
       strongBallHits = ballHits * 2;
    }

    void Update()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ball")
        {
            GameObject.FindObjectOfType<Spawn>().score++;
            if(gameObject.tag == "WeakBlock")
            {
                weakBallHits--;
            }

            if(gameObject.tag == "StrongBlock")
            {
                strongBallHits--;

            }

            if(gameObject.tag == "WeakBlock" && weakBallHits == 0)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawn>().BlockList.Remove(this.gameObject);
                Destroy(gameObject);
            }

            if (gameObject.tag == "StrongBlock" && strongBallHits == 0)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawn>().BlockList.Remove(this.gameObject);
                Destroy(gameObject);    
            }

        }

    }
}