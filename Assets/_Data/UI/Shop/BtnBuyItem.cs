using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBuyItem : ButttonAbstract
{
    [SerializeField] protected ItemShop itemShop;
    protected InventoryCtrl inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemShop();
    }
    protected virtual void LoadItemShop()
    {
        if (this.itemShop != null) return;
        this.itemShop = GetComponentInParent<ItemShop>();
        Debug.Log(transform.name + " : LoadItemShop", gameObject);
    }
  
    protected virtual bool CheckCurrency()
    {
        this.inventory = InventoriesManager.Instance.Currency();
        if (this.inventory == null) return false;
        
        ItemInventory itemInventory = inventory.FindItem(ItemCode.Gold);
        if (itemInventory == null) return false;
        
        int currentGold = itemInventory.itemCount;
        return currentGold >= this.itemShop.Price;
    }
  
    protected virtual void BuyItem()
    {
        if (this.CheckCurrency())
        {
            InventoriesManager.Instance.AddItem(this.itemShop.GetItemCode(), 1);
            InventoriesManager.Instance.RemoveItem(ItemCode.Gold, this.itemShop.Price);
            UIShop.Instance.DisplayNotification("Sucessful!!!!");

        }
        else UIShop.Instance.DisplayNotification("Not enough gold, broooo!!!!!");

    }
    public override void OnClick()
    {
        this.BuyItem();
    }
}
