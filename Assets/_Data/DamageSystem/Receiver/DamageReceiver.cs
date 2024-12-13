using UnityEngine;

public abstract class DamageReceiver : SaiBehaviour, IHpBarInterface
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false; //Bat tu
    [SerializeField] protected bool isHit = false;


    public virtual void Receiver(int damage, DamageSender damageSender)
    {
         if (!this.isImmotal) this.currentHP -= damage;
         if (this.currentHP < 0) this.currentHP = 0;

         if (this.IsDead()) this.OnDead();
         else this.OnHurt();
    }
    //Ham duoc goi khi enable
    protected virtual void OnEnable()
    {
        this.Reborn();
    }
    protected virtual void Reborn()
    {
        this.currentHP = this.maxHP;
    }

    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }
    protected abstract void OnDead();

    protected abstract void OnHurt();

    public virtual int HP()
    {
        return this.currentHP;
    }
}
