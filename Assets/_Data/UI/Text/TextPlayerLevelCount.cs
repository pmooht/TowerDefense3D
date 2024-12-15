using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPlayerLevelCount : TextAbstract
{
    [SerializeField] protected LevelByPlayerExp levelByPlayerExp;

    protected virtual void FixedUpdate()
    {
        this.UpdateLevel();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelByPlayerExp();
    }

    protected virtual void LoadLevelByPlayerExp()
    {
        if (this.levelByPlayerExp != null ) return;
        this.levelByPlayerExp = GameObject.FindObjectOfType<LevelByPlayerExp>();
        Debug.Log(transform.name + ": LoadLevelByPlayerExp", gameObject);
    }

    protected virtual void UpdateLevel()
    {
        this.textPro.text = this.levelByPlayerExp.CurrentLevel.ToString();
    }
    
   


}
