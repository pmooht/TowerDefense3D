using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [SerializeField] protected ItemInventory itemInventory;

    protected abstract ItemCode GetItemCodeName();

    protected override bool DeductExp(int exp)
    {
        return this.GetPLayerExp().Deduct(exp);
    }

    protected override int GetCurrentExp()
    {
        if (this.GetPLayerExp() == null) return 0;
        return this.GetPLayerExp().itemCount;
    }

    protected virtual ItemInventory GetPLayerExp()
    {
        if (this.itemInventory == null || this.itemInventory.ItemID == 0)
            this.itemInventory = InventoriesManager.Instance.Currency().FindItem(this.GetItemCodeName());
        return this.itemInventory;
    }
}
