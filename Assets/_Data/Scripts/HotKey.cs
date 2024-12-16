using UnityEngine;

public class Hotkey : SaiSingleton<Hotkey>
{
    protected bool isToogleInventoryUI = false;
    public bool IsToogleInventoryUI => isToogleInventoryUI;

    protected bool isToogleMusic = false;
    public bool IsToogleMusic => isToogleMusic;

    protected bool isToogleSetting = false;
    public bool IsToogleSetting => isToogleSetting;

    protected bool isToggleShopUI = false;
    public bool IsToggleShopUI => isToggleShopUI;

    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
        this.ToogleSetting();
        this.ToggleShop();
    }

    protected virtual void OpenInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
    }

    protected virtual void ToogleSetting()
    {
        this.isToogleSetting = Input.GetKeyUp(KeyCode.Escape);
    }
    protected virtual void ToggleShop()
    {
        this.isToggleShopUI = Input.GetKeyUp(KeyCode.B);
    }
}
