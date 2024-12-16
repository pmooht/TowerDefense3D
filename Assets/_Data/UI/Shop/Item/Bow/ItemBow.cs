using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBow : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Bow;
    }

    public override int SetPrice()
    {
        return this.price = 40;
    }
}
