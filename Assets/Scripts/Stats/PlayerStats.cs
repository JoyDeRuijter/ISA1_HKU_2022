// Written by Joy de Ruijter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    #region Variables

    public Stat money;
    public Stat disguise;

    #endregion

    private void Awake()
    {
        MaskManager.instance.onMaskChanged += OnMaskChanged;
        money.SetStatValue(money.baseValue);
        disguise.SetStatValue(disguise.baseValue);
    }

    void OnMaskChanged(MaskItem newMask)
    {
        if (newMask != null)
            disguise.SetStatValue(newMask.disguise);
    }

    public void UpdateMoney(bool shouldAdd, int value)
    { 
        if (shouldAdd)
            money.AddValue(value);
        else
            money.SubtractValue(value);
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
