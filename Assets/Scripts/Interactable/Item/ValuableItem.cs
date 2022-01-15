// Written by Joy de Ruijter
using UnityEngine;

[CreateAssetMenu(fileName = "New Valuable", menuName = "Interactables/Valuable")]
public class ValuableItem : Item
{
    #region Variables

    public int value;

    #endregion

    public override void Use()
    { 
        base.Use();

        Debug.Log("Does what it's supposed to");
        PlayerStats.instance.UpdateMoney(true, value);
        RemoveFromInventory();
    }
}
