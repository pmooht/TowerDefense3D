using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [Header("Shooting")]
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected EffectCode bulletCode = EffectCode.Projectile1;
    [SerializeField] protected EffectCode heavyBulletCode = EffectCode.HeavyBullet;
    [SerializeField] protected EffectCode muzzleCode = EffectCode.Muzzle1;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1f;
    [SerializeField] protected int firePointIndex = 0;
    [SerializeField] protected int heavyFirePointIndex = 0;
    [SerializeField] protected List<FirePoint> firePoints = new();
    [SerializeField] protected int normalBulletCounter = 0; // Dem so lan ban dan thuong
    [SerializeField] protected int heavyAttackThreshold = 10; // So lan ban dan thuong de kich hoat heavyAttack
    [SerializeField] protected int killCount = 0;
    public int KillCount => killCount;

    [SerializeField] protected int totalKill = 0;

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
        this.IsTargetDead();
    }
    protected virtual void GetTarget()
    {
        if (this.target != null) return;
        this.target = this.ctrl.Radar.GetTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        this.ctrl.Rotator.LookAt(this.target.transform.position);
    }

    protected virtual void Shooting()
    {
        this.timer += Time.deltaTime;
        if (this.target == null) return;
        if (this.timer < this.delay) return;
        this.timer = 0;

        FirePoint firePoint = this.GetFirePoint();
        FirePoint heavyFirePoint = this.GetHeavyFirePoint();

        if (this.normalBulletCounter >= this.heavyAttackThreshold)
        {
            this.SpawnHeavyAttack(heavyFirePoint); 
            this.normalBulletCounter = 0; 
            return;
        }
        this.SpawnBullet(firePoint);
        this.SpawnMuzzle(firePoint);
        this.normalBulletCounter++;
    }

    protected virtual EffectCtrl SpawnBullet(FirePoint firePoint)
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.bulletCode.ToString());
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position, firePoint.transform.rotation);
        newEffect.gameObject.SetActive(true);

        return prefab;
    }
    protected virtual EffectCtrl SpawnMuzzle(FirePoint firePoint)
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.muzzleCode.ToString());
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position, firePoint.transform.rotation);
        newEffect.gameObject.SetActive(true);

        return prefab;
    }
    protected virtual EffectCtrl SpawnHeavyAttack(FirePoint firePoint)
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.heavyBulletCode.ToString());
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position, firePoint.transform.rotation );
        newEffect.gameObject.SetActive(true);

        return prefab;
    }

    protected virtual FirePoint GetFirePoint()
    {
        this.firePointIndex++;
        if (this.firePointIndex >= this.firePoints.Count) this.firePointIndex = 0;
        return this.firePoints[this.firePointIndex];
    }
    protected virtual FirePoint GetHeavyFirePoint()
    {
        if (this.heavyFirePointIndex < this.firePoints.Count)
            return this.firePoints[this.heavyFirePointIndex];
        return this.firePoints[0];
    }

    protected virtual void LoadFirePoint()
    {
        if (this.firePoints.Count > 0 ) return;
        FirePoint[] points = this.ctrl.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.LogWarning(transform.name + ": LoadFirePoint", gameObject);
    }
    protected virtual bool IsTargetDead()
    {
        if (this.target == null) return true;
        if (!this.target.EnemyDamageReceiver.IsDead()) return false;
        this.killCount++;
        this.totalKill++;
        this.target = null;
        return true;
    }
    
    public virtual bool DeductKillCount(int count)
    {
        if (this.killCount < count) return false;
        this.killCount -= count;
        return true;
    }
}
