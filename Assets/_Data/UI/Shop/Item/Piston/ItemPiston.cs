using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPiston : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Piston;
    }

    public override int SetPrice()
    {
        return this.price = 20;
    }
}
