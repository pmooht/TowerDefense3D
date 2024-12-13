using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtTowerLevel : TxtLevel
{
    [SerializeField] protected TowerCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }
    protected virtual void LoadTowerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }
    protected override string GetLevel()
    {
        return this.ctrl.Level.CurrentLevel.ToString();
    }
}
