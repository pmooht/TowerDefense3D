using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ItemShop : SaiBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPrice;
    [SerializeField] protected int price;
    public int Price => price;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPrice();
        this.SetPrice();
        this.UpdatePrice();
    }
    
    protected virtual void LoadTextPrice()
    {
        if (this.textPrice != null) return;
        this.textPrice = transform.Find("TxtPriceLabel").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + " : LoadTextPrice", gameObject);
    }
    public abstract ItemCode GetItemCode();

    public abstract int SetPrice();

    protected virtual void UpdatePrice()
    {
        this.textPrice.text = this.price.ToString() + " G";
    }



}
