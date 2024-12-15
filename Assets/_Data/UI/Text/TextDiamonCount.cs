using UnityEngine;
using TMPro;

public class TextDiamonCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadDiamonCount();
    }

    protected virtual void LoadDiamonCount()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.Diamon);
        string diamonCount;
        if (item == null) diamonCount = "0";
        else diamonCount = item.itemCount.ToString();
        this.textPro.text = diamonCount;
    }
}
