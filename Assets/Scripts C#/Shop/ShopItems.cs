/*
 * ShopItems.cs
 * Handles the shop allowing you to unlock items by spending
 * currency you can earn from playing games or by not smoking
 * for a long period of time.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ShopItems : MonoBehaviour
{
    public GameObject ShopLocked;
    public GameObject ShopAppliedMJ,        ShopOwnedMJ,        ShopUnlockedMJ;
    public GameObject ShopAppliedSnake,     ShopOwnedSnake,     ShopUnlockedSnake;
    public GameObject ShopAppliedBricks,    ShopOwnedBricks,    ShopUnlockedBricks;
    public GameObject BricksGrid,           SnakeGrid,          BBTanGrid;
    public ShopHandling handler;

    Color[] LerpTab = new Color[5];
    Color color;

    int looper = 0;

    private List<GameObject> rainbowList = new List<GameObject>();

    void Start()
    {
        LerpTab[0] = Color.red;
        LerpTab[1] = Color.yellow;
        LerpTab[2] = Color.green;
        LerpTab[3] = Color.cyan;
        LerpTab[4] = Color.magenta;

        color = Color.red;

        if (GameController.control.PlayerData.ShopInventory != null) { SpawnShop(); return; }

        List<ShopItem> bricksItems = new List<ShopItem>(), snakeItems = new List<ShopItem>(), maruJumpItems = new List<ShopItem>();
        List<List<ShopItem>> shopInventory = new List<List<ShopItem>>();

        //Add Bricks items.
        bricksItems.Add(new ShopItem(ShopItem.itemType.bricks, "Red Panel", 100, Color.red, ShopItem.itemState.unlocked));
        bricksItems.Add(new ShopItem(ShopItem.itemType.bricks, "Blue Panel", 200, Color.cyan, ShopItem.itemState.unlocked));
        bricksItems.Add(new ShopItem(ShopItem.itemType.bricks, "Green Panel", 250, Color.green, ShopItem.itemState.unlocked));
        bricksItems.Add(new ShopItem(ShopItem.itemType.bricks, "Yellow Panel", 300, Color.yellow, ShopItem.itemState.unlocked));
        bricksItems.Add(new ShopItem(ShopItem.itemType.bricks, "Pink Panel", 300, Color.magenta, ShopItem.itemState.unlocked));
        bricksItems.Add(new ShopItem(ShopItem.itemType.bricks, "Black Panel", 300, Color.black, ShopItem.itemState.unlocked));
        //bricksItems.Add(new ShopItem(ShopItem.itemType.bricks, "Rainbow Panel", 1000, Color.tobecontinued, ShopItem.itemState.locked));
        
        //Add Snake items.
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Red Snake", 100, Color.red, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Blue Snake", 200, Color.cyan, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Green Snake", 250, Color.green, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Yellow Snake", 300, Color.yellow, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Pink Snake", 300, Color.magenta, ShopItem.itemState.unlocked));
        //snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Rainbow Snake", 1000, Color.tobecontinued, ShopItem.itemState.locked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Blue Apple", 200, Color.blue, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Green Apple", 300, Color.green, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Yellow Apple", 300, Color.yellow, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Pink Apple", 400, Color.magenta, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Black Apple", 400, Color.black, ShopItem.itemState.unlocked));
        snakeItems.Add(new ShopItem(ShopItem.itemType.snake, "Rainbow Apple", 1200, Color.red, ShopItem.itemState.unlocked));

        //Add BB-Tan items.
        maruJumpItems.Add(new ShopItem(ShopItem.itemType.maru, "Red Donut", 100, Color.red, ShopItem.itemState.locked));
        maruJumpItems.Add(new ShopItem(ShopItem.itemType.maru, "Blue Donut", 200, Color.red, ShopItem.itemState.locked));
        maruJumpItems.Add(new ShopItem(ShopItem.itemType.maru, "Green Donut", 250, Color.red, ShopItem.itemState.locked));
        maruJumpItems.Add(new ShopItem(ShopItem.itemType.maru, "Yellow Donut", 300, Color.red, ShopItem.itemState.locked));
        maruJumpItems.Add(new ShopItem(ShopItem.itemType.maru, "Pink Dog", 300, Color.red, ShopItem.itemState.locked));
        maruJumpItems.Add(new ShopItem(ShopItem.itemType.maru, "Purple Donut", 400, Color.red, ShopItem.itemState.locked));
        maruJumpItems.Add(new ShopItem(ShopItem.itemType.maru, "Rainbow Dog", 1000, Color.red, ShopItem.itemState.locked));

        //Add item lists to the shop inventory list.
        shopInventory.Add(bricksItems);
        shopInventory.Add(snakeItems);
        shopInventory.Add(maruJumpItems);

        GameController.control.PlayerData.ShopInventory = shopInventory;
        GameController.control.PlayerData.saveData();

        SpawnShop();
    }

    void Update()
    {
        for (int i = 0; i < rainbowList.Count; i++)
        {
            float t = Time.deltaTime * 10;

            color = Color.Lerp(color, LerpTab[looper], t);

            if (color == LerpTab[looper])
            {
                looper++;
                looper = looper % LerpTab.Length;
            }
            rainbowList[i].GetComponent<Image>().color = color;

           /*
            * In case you want a seizure, uncomment this. ~Pixel Artists
            * 
            * rainbowList[i].GetComponentsInChildren<Image>()[0].color = color;
            * rainbowList[i].GetComponentsInChildren<Image>()[1].color = color;
            * rainbowList[i].GetComponentsInChildren<Image>()[2].color = color;
            */
        }

    }

    private void SpawnShop()
    {
        Transform brickParent = BricksGrid.transform, snakeParent = SnakeGrid.transform, bbtanParent = BBTanGrid.transform;

        //For every game mode there is a seperate list of items.
        foreach (List<ShopItem> invType in GameController.control.PlayerData.ShopInventory)
        {
            //Here we will take a seperated list from a game mode and obtain every item in that list.
            foreach (ShopItem item in invType)
            {
                //Checks whether the item in that list is unlocked or not.
                switch (item.state)
                {

                    //Fetches the item type and places it in the corresponding row.
                    //If it is unlocked, the box will have no lock displayed on top.
                    //If it is locked, the box will have a locked displayed on top.
                    case ShopItem.itemState.unlocked:
                        switch (item.type)
                        {
							case ShopItem.itemType.bricks:
								GameObject brickItem = Instantiate (ShopUnlockedBricks, brickParent) as GameObject;
								Button brickButton = brickItem.GetComponent<Button> ();
                                brickButton.onClick.AddListener(() => handler.buyItem(item));
                                brickButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                brickButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                break;
                            case ShopItem.itemType.snake:
                                if (GameController.control.PlayerData.Level >= 3)
                                {
                                    GameObject snakeItem = Instantiate(ShopUnlockedSnake, snakeParent) as GameObject;
                                    Button snakeButton = snakeItem.GetComponent<Button>();
                                    snakeButton.onClick.AddListener(() => handler.buyItem(item));
                                    snakeButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                    snakeButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                }
                                break;       
                            case ShopItem.itemType.bbtan:
                                if (GameController.control.PlayerData.Level >= 5)
                                {
                                    GameObject bbtanItem = Instantiate(ShopUnlockedMJ, bbtanParent) as GameObject;
                                    Button bbtanButton = bbtanItem.GetComponent<Button>();
                                    bbtanButton.onClick.AddListener(() => handler.buyItem(item));
                                    bbtanButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                    bbtanButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                }
                                break;
                        }
                        break;

                    case ShopItem.itemState.owned:
                        switch (item.type)
                        {
                            case ShopItem.itemType.bricks:
                                GameObject brickItem = Instantiate(ShopOwnedBricks, brickParent) as GameObject;
                                Button brickButton = brickItem.GetComponent<Button>();
                                brickButton.onClick.AddListener(() => handler.activateItem(invType, item));
                                brickButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                brickButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                break;
                            case ShopItem.itemType.snake:
                                GameObject snakeItem = Instantiate(ShopOwnedSnake, snakeParent) as GameObject;
                                Button snakeButton = snakeItem.GetComponent<Button>();
                                snakeButton.onClick.AddListener(() => handler.activateItem(invType, item));
                                snakeButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                snakeButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                break;
                            case ShopItem.itemType.bbtan:
                                GameObject bbtanItem = Instantiate(ShopOwnedMJ, bbtanParent) as GameObject;
                                Button bbtanButton = bbtanItem.GetComponent<Button>();
                                bbtanButton.onClick.AddListener(() => handler.activateItem(invType, item));
                                bbtanButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                bbtanButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                break;
                        }
                        break;

                    case ShopItem.itemState.applied:
                        switch (item.type)
                        {
                            case ShopItem.itemType.bricks:
                                GameObject brickItem = Instantiate(ShopAppliedBricks, brickParent) as GameObject;
                                Button brickButton = brickItem.GetComponent<Button>();
                                brickButton.onClick.AddListener(() => handler.Deactivate(invType, item));
                                brickButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                brickButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                rainbowList.Add(brickItem);
                                break;
                            case ShopItem.itemType.snake:
                                GameObject snakeItem = Instantiate(ShopAppliedSnake, snakeParent) as GameObject;
                                Button snakeButton = snakeItem.GetComponent<Button>();
                                snakeButton.onClick.AddListener(() => handler.Deactivate(invType, item));
                                snakeButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                snakeButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                rainbowList.Add(snakeItem);
                                break;
                            case ShopItem.itemType.bbtan:
                                GameObject bbtanItem = Instantiate(ShopAppliedMJ, bbtanParent) as GameObject;
                                Button bbtanButton = bbtanItem.GetComponent<Button>();
                                bbtanButton.onClick.AddListener(() => handler.Deactivate(invType, item));
                                bbtanButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                bbtanButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                rainbowList.Add(bbtanItem);
                                break;
                        }
                        break;

                    default:
                        switch (item.type)
                        {
                            case ShopItem.itemType.bricks:
                                GameObject brickItem = Instantiate(ShopLocked, brickParent) as GameObject;
                                Button brickButton = brickItem.GetComponent<Button>();
                                brickButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                brickButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                break;
                            case ShopItem.itemType.snake:
                                if (GameController.control.PlayerData.Level >= 3)
                                {
                                    GameObject snakeItem = Instantiate(ShopLocked, snakeParent) as GameObject;
                                    Button snakeButton = snakeItem.GetComponent<Button>();
                                    snakeButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                    snakeButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                }
                                break;
                            case ShopItem.itemType.bbtan:
                                if (GameController.control.PlayerData.Level >= 5)
                                {
                                    GameObject bbtanItem = Instantiate(ShopLocked, bbtanParent) as GameObject;
                                    Button bbtanButton = bbtanItem.GetComponent<Button>();
                                    bbtanButton.GetComponentsInChildren<Text>()[0].text = item.name;
                                    bbtanButton.GetComponentsInChildren<Text>()[1].text = item.price.ToString() + " coins";
                                }
                                break;
                        }

                    break;
                }
            }
        }
    }
}


