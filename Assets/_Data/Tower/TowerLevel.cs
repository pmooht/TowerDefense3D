using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel : LevelAbstract
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
    protected override bool DeductExp(int exp)
    {
        return this.ctrl.TowerShooting.DeductKillCount(exp);
    }

    protected override int GetCurrentExp()
    {
        return this.ctrl.TowerShooting.KillCount;
    }
}
