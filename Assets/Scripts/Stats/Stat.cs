// Written by Joy de Ruijter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    #region Variables

    [SerializeField] private int baseValue;
    [SerializeField] private int maxValue;
    [SerializeField] private int minValue;
    public int currentValue { private set; get; }

    #endregion

    public int GetStatValue()
    {
        return currentValue;
    }

    public void SetStatValue(int valueToSet)
    { 
        currentValue = valueToSet;
    }

    public void AddValue(int valueToAdd)
    {
        if (valueToAdd <= 0)
        {
            Debug.Log("A negative number can't be added to a stat!");
            return;
        }

        if (currentValue + valueToAdd > maxValue)
            currentValue = maxValue;
        else
            currentValue += valueToAdd;
    }

    public void SubtractValue(int valueToSubtract)
    {
        if (valueToSubtract <= 0)
        {
            Debug.Log("A negative number can't be subtracted from a stat!");
            return;
        }

        if (currentValue - valueToSubtract < minValue)
            currentValue = minValue;
        else
            currentValue -= valueToSubtract;
    }
}
