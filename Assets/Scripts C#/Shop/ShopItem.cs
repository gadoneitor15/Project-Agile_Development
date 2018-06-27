/*
 * ShopItem.cs
 * Handles all items which can be purchased from the ShopItems.cs
 * Items that are unlocked will be triggered by an unlocked boolean
 * which means the item is owned.
 */

using System;
using UnityEngine;

[Serializable]
public class ShopItem
{
    public string name;
    public int price;
    public itemType type;
    public itemState state;
    private float[] color = new float[4];

    // Getter and setter for the colors.
    public Color Color
    {
        get
        {
            return new Color(color[0], color[1], color[2], color[3]);
        }
        set
        {
            color[0] = value.r;
            color[1] = value.g;
            color[2] = value.b;
            color[3] = value.a;
        }
    }

    public ShopItem(itemType type, string name, int price, Color color, itemState state)
    {
        this.state = state;
        this.name = name;
        this.type = type;
        this.price = price;
        this.Color = color;
    }

    // Enumerator in which cointains the types of games we have.
    public enum itemType
    {
        bricks = 0,
        snake = 1,
        bbtan = 2,
        maru = 3,
    }

    public enum itemState
    {
        locked = 0,         //Item is unavailable and cannot be purchased.
        unlocked = 1,       //Item is not owned but can be purchased.
        owned = 2,          //Item is owned and cannot be purchased.
        applied = 3         //Item's effect is applied.
    }
}