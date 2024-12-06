using UnityEngine;
using TMPro;

public class TextAbstract : SaiBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPro;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }
    protected virtual void LoadTextPro()
    {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTextpro", gameObject);
    }
}
