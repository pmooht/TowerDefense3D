using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWand : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Wand;
    }

    public override int SetPrice()
    {
        return this.price = 10;
    }
}
