using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFood : MonoBehaviour
{

    // Declareren van een GameObject
    public GameObject foodPrefab;

    // Declareren van de muren
    public Transform lijn_onder;
    public Transform lijn_links;
    public Transform lijn_boven;
    public Transform lijn_rechts;

    void Start()
    {
        foodPrefab.GetComponent<SpriteRenderer>().color= GameController.control.PlayerData.AppleColor;
        Spawn();
    }

    // Deze methode is voor het aanmaken van voedsel tussen de muren
    // (int) staat voor Random zodat voed altijd wordt afgerond tot positie (3, 5) ipv (3,45 ; 5,29)
    public void Spawn()
    {
        // Deze regel code zorgt ervoor dat voedsel op een random plek >> x << komt tussen de linker en rechter muur
        int x = (int)Random.Range(lijn_links.position.x + 0.5f, lijn_rechts.position.x - 0.5f);

        // Deze regel code zorgt ervoor dat voedsel op een random plek >> y << komt tussen de onderste en bovenste muur
        int y = (int)Random.Range(lijn_onder.position.y + 0.5f, lijn_boven.position.y - 0.5f);
        
        // Bevestigen van de plek op (x, y)
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
