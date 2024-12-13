using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text3DAbstract : SaiBehaviour
{
    [SerializeField] protected TextMeshPro textMeshPro;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }
    protected virtual void LoadTextMeshPro()
    {
        if (this.textMeshPro != null) return;
        this.textMeshPro = GetComponent<TextMeshPro>();
        Debug.Log(transform.name + ": LoadTextMeshPro", gameObject);
    }

}
