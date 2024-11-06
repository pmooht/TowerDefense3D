using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(SphereCollider))]
public class TowerRadar : SaiBehaviour
{
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected List<EnemyCtrl> enemies = new();

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadCollider();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 12;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;
        this.AddEnemy(enemyCtrl);
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;
        this.RemoveEnemy(enemyCtrl);
    }

    protected virtual void AddEnemy(EnemyCtrl enemyCtrl)
    {
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(EnemyCtrl enemyCtrl)
    {
       if (this.nearest == enemyCtrl) this.nearest = null;
        this.enemies.Remove(enemyCtrl);
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }
    }

    public virtual EnemyCtrl GetTarget()
    {
        return this.nearest;
    }

}
