using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
    [SerializeField] protected ItemDropCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponentInParent<ItemDropCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    public override void DoDespawn()
    {
        base.DoDespawn();
        // Phan loai vat pham de them vao inventory
        InventoriesManager.Instance.AddItem(this.ctrl.GetItemCode(), this.ctrl.DropCount);
    }
}
