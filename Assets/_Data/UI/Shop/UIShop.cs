using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShop : SaiSingleton<UIShop>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;

    [SerializeField] protected Transform showHide;
    [SerializeField] protected TextMeshProUGUI notificationText; 

    protected override void Start()
    {
        base.Start();
        this.Hide();
        this.HideNotification();
    }
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleShop();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowHide();
        this.LoadNotification();
    }
    protected virtual void LoadShowHide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.name + ": LoadShowHide", gameObject);
    }
    protected virtual void LoadNotification()
    {
        if (this.notificationText != null) return;
        this.notificationText = GameObject.Find("Notification").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadNotification", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        this.showHide.gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        this.showHide.gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void ShowNotification()
    {
        this.notificationText.gameObject.SetActive(true);
    }

    protected virtual void HideNotification()
    {
        this.notificationText.gameObject.SetActive(false);
    }

    public virtual void DisplayNotification(string message)
    {
        this.notificationText.text = message;
        this.ShowNotification();
        Invoke(nameof(HideNotification), 1.0f);
    }
    protected virtual void HotkeyToogleShop()
    {
        if (Hotkey.Instance.IsToggleShopUI) UIManager.Instance.ToggleShop();
    }
}
