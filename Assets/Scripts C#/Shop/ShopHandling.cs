using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandling : MonoBehaviour {

    public void buyItem(ShopItem item)
    {
        if (GameController.control.PlayerData.Balance < item.price)
            return;

        GameController.control.PlayerData.Balance -= item.price;
        item.state = ShopItem.itemState.owned;
        GameController.control.PlayerData.saveData();
        nextScene.switchScene("ShopMain");
    }

    public void activateItem(List<ShopItem> items, ShopItem item)
    {
        
        switch(item.type)
        {
            case ShopItem.itemType.bbtan:
                items.ForEach(x => { if (x.state == ShopItem.itemState.applied) x.state = ShopItem.itemState.owned; });
                item.state = ShopItem.itemState.applied;
                GameController.control.PlayerData.BBtanBallColor = item.Color;
                GameController.control.PlayerData.saveData();
                nextScene.switchScene("ShopMain");
                break;
            case ShopItem.itemType.bricks:
                items.ForEach(x => { if (x.state == ShopItem.itemState.applied) x.state = ShopItem.itemState.owned; });
                item.state = ShopItem.itemState.applied;
                GameController.control.PlayerData.PaddleColor = item.Color;
                GameController.control.PlayerData.saveData();
                nextScene.switchScene("ShopMain");
                break;
            case ShopItem.itemType.snake:
                if (item.name.Contains("Snake"))
                {
                    items.ForEach(x => { if (x.state == ShopItem.itemState.applied && x.name.Contains("Snake")) x.state = ShopItem.itemState.owned; });
                    item.state = ShopItem.itemState.applied;
                    GameController.control.PlayerData.SnakeColor = item.Color;
                    GameController.control.PlayerData.saveData();
                    nextScene.switchScene("ShopMain");
                }
                else if (item.name.Contains("Apple"))
                {
                    items.ForEach(x => { if (x.state == ShopItem.itemState.applied && x.name.Contains("Apple")) x.state = ShopItem.itemState.owned; });
                    item.state = ShopItem.itemState.applied;
                    GameController.control.PlayerData.AppleColor = item.Color;
                    GameController.control.PlayerData.saveData();
                    nextScene.switchScene("ShopMain");
                }
                break;
        }
    }

    public void Deactivate(List<ShopItem> items, ShopItem item)
    {
        

        switch (item.type)
        {
            case ShopItem.itemType.bbtan:
                items.ForEach(x => { if (x.state == ShopItem.itemState.applied) x.state = ShopItem.itemState.owned; });
                GameController.control.PlayerData.BBtanBallColor = Color.white;
                break;
            case ShopItem.itemType.bricks:
                items.ForEach(x => { if (x.state == ShopItem.itemState.applied) x.state = ShopItem.itemState.owned; });
                GameController.control.PlayerData.PaddleColor = Color.white;
                break;
            case ShopItem.itemType.snake:
                if (item.name.Contains("Snake"))
                {
                    items.ForEach(x => { if (x.state == ShopItem.itemState.applied && x.name.Contains("Snake")) x.state = ShopItem.itemState.owned; });
                    GameController.control.PlayerData.SnakeColor = Color.white;
                }
                else if (item.name.Contains("Apple"))
                {
                    items.ForEach(x => { if (x.state == ShopItem.itemState.applied && x.name.Contains("Apple")) x.state = ShopItem.itemState.owned; });
                    GameController.control.PlayerData.AppleColor = Color.white;
                }
                break;
        }
        nextScene.switchScene("ShopMain");
    }

	public void test (){
        Debug.Log("Test");
        GameController.control.PlayerData.Balance += 10;
        GameController.control.PlayerData.saveData();
    }

}
