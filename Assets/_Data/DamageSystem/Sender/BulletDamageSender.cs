using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDamageSender : DamageSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EffectDespawn despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;

        Transform parentTransform = transform.parent;
        if (parentTransform == null) return;

        foreach (Transform sibling in parentTransform)
        {
            if (sibling == transform) continue;

            EffectDespawn effectDespawn = sibling.GetComponent<EffectDespawn>();
            if (effectDespawn != null)
            {
                despawn = effectDespawn;
                break;
            }
        }
    }

    //protected virtual void LoadDespawn()
    //{
    //    if (this.despawn != null) return;
    //    this.despawn = transform.parent.GetComponent<EffectDespawn>(); ;
    //    Debug.Log(transform.name + ": LoadDespawn", gameObject);
    //}
    protected override void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        this.sphereCollider = (SphereCollider)this._collider;
        this.sphereCollider.radius = 0.3f;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }
    protected override DamageReceiver SendDamage(Collider collider)
    {
        DamageReceiver damageReceiver = base.SendDamage(collider);
        if (damageReceiver == null) return null;
        this.despawn.DoDespawn();
        return damageReceiver;
    }
}
