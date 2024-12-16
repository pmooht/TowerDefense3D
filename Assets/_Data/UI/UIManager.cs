using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SaiSingleton<UIManager>
{
    [SerializeField] protected UIInventory uIInventory;
    public UIInventory UIInventory => uIInventory;

    [SerializeField] protected UIShop uIShop;
    public UIShop UIShop => uIShop;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventory();
        this.LoadUIShop();
    }

    protected virtual void LoadUIInventory()
    {
        if (this.uIInventory != null) return;
        this.uIInventory = GetComponentInChildren<UIInventory>();
        Debug.Log(transform.name + ": LoadUIInventory", gameObject);
    }
    protected virtual void LoadUIShop()
    {
        if (this.uIShop != null) return;
        this.uIShop = GetComponentInChildren<UIShop>();
        Debug.Log(transform.name + ": LoadUIShop", gameObject);
    }
    public virtual void ToggleShop()
    {
        if (!this.UIShop.IsShow)
        {
            UIInventory.Hide();
            UIShop.Show();
        }
        else
        {
            UIShop.Hide();
        }
    }

    public virtual void ToggleInventory()
    {
        if (!this.UIInventory.IsShow)
        {
            UIShop.Hide();
            UIInventory.Show();
        }
        else
        {
            UIInventory.Hide();
        }
    }
}
