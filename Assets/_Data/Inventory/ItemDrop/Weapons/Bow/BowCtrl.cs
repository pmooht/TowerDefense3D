using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCtrl : ItemDropCtrl
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Bow;
    }
}
