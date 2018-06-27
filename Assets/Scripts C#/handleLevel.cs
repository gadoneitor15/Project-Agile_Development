using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleLevel : MonoBehaviour {

    public GameObject Bricks, Snake, BBtan;

    public void Start()
    {
        switch (GameController.control.PlayerData.Level)
        {
            case 5:
                BBtan.SetActive(true);
                goto case 3;
            case 4:
            case 3:
                Snake.SetActive(true);
                goto case 1;
            case 2:
            case 1:
                Bricks.SetActive(true);
                break;
        }
    }
}
