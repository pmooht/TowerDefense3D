using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UIHpBar : SaiBehaviour
{
    [SerializeField] protected Transform HpBarData;
    [SerializeField] protected Slider slider;

    protected virtual void FixedUpdate()
    {
        this.UpdateHpBar();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHpBarData();
        this.LoadSlider();
    }

    protected virtual void LoadHpBarData()
    {
        if (this.HpBarData != null) return;
        this.HpBarData = transform.parent.parent.parent.Find("DamageReceiver").GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadHpBarData", gameObject);
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }
    protected virtual void UpdateHpBar()
    {
        if (this.slider == null) return;
        IHpBarInterface hpBarInterface = this.HpBarData.GetComponent<IHpBarInterface>();
        if (hpBarInterface == null) return;
        this.slider.value = hpBarInterface.HP();
    }
}
