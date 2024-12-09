using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [Header("Shooting")]
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected EffectCtrl bullet;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1f;
    [SerializeField] protected int firePointIndex = 0;
    [SerializeField] protected List<FirePoint> firePoints = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoint();
    }
    protected virtual void FixedUpdate()
    {
        this.GetTarget();
        this.LookAtTarget();
        this.Shooting();
    }
    protected virtual void GetTarget()
    {
        this.target = this.ctrl.Radar.GetTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        this.ctrl.Rotator.LookAt(this.target.transform.position);
    }
    //protected virtual void LookAtTarget()
    //{
    //    if (this.target == null) return;

    //    Collider collider = this.target.transform.Find("DamageReceiver").GetComponent<Collider>();
    //    if (collider == null) return;
    //    Vector3 targetPosition = collider.bounds.center;
    //    this.ctrl.Rotator.LookAt(targetPosition);
    //    Debug.DrawLine(this.ctrl.Rotator.position, targetPosition, Color.red, 2f);
    //}



    protected virtual void Shooting()
    {
        this.timer += Time.deltaTime;
        if (this.target == null) return;
        if (this.timer < this.delay) return;
        this.timer = 0;

        FirePoint firePoint = this.GetFirePoint();
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(this.bullet, firePoint.transform.position, firePoint.transform.rotation);
        //Co the thay doi vi tri 
        //newEffect.transform.position = new Vector3(1, 2, 3);
        newEffect.gameObject.SetActive(true);
    }
    protected virtual FirePoint GetFirePoint()
    {
        this.firePointIndex++;
        if (this.firePointIndex >= this.firePoints.Count) this.firePointIndex = 0;
        return this.firePoints[this.firePointIndex];
    }
    protected virtual void LoadFirePoint()
    {
        if (this.firePoints.Count > 0 ) return;
        FirePoint[] points = this.ctrl.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.LogWarning(transform.name + ": LoadFirePoint", gameObject);
    }
}
