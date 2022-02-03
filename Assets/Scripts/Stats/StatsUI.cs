// Written by Joy de Ruijter
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    #region Variables

    [HideInInspector] public Text counter;
    [HideInInspector] public int value = 0;
    [HideInInspector] public string statName;

    #endregion

    protected virtual void Update()
    {
        DisplayCounter();
    }

    private void DisplayCounter()
    {
        counter.text = statName + ":  " + value;
    }
}
