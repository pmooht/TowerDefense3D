using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnToggleShop : ButttonAbstract
{
    public override void OnClick()
    {
        UIShop.Instance.Toggle();
    }
}
