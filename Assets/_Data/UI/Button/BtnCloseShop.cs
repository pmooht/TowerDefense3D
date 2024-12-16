using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseShop : ButttonAbstract
{
    public override void OnClick()
    {
        UIShop.Instance.Hide();
    }
}
