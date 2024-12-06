using UnityEngine;
using TMPro;

public class TextExpCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadExpCount();
    }

    protected virtual void LoadExpCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.PlayerExp);
        string expCount;
        if (item == null) expCount = "0";
        else expCount = item.itemCount.ToString();
        this.textPro.text = expCount;
    }
}
