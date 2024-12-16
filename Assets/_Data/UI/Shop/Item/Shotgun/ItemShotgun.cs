using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShotgun : ItemShop
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Shotgun;
    }

    public override int SetPrice()
    {
        return this.price = 50;
    }
}
