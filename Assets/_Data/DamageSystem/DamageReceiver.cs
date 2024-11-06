using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : SaiBehaviour
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false; //Bat tu
    public virtual void Receiver(int damage, DamageSender damageSender)
    {
        this.currentHP -= damage;
    }

}
