using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByPlayerExp : LevelByItem
{
    protected override ItemCode GetItemCodeName()
    {
       return ItemCode.PlayerExp;
    }
}
