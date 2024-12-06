using UnityEngine;
using TMPro;

public class TextGoldCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadGoldCount();
    }

    protected virtual void LoadGoldCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.Gold);
        string goldCount;
        if (item == null) goldCount = "0";
        else goldCount = item.itemCount.ToString();
        this.textPro.text = goldCount;
    }
}
