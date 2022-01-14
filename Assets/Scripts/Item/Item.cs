// Written by Joy de Ruijter
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Interactables/Item")]
public class Item : ScriptableObject
{
    #region Variables

    public enum ItemType { Test, Mask }
    public ItemType itemType;

    [HideInInspector] public bool isEquipped;
    public bool isDefaultMask = false;
    new public string name = "Insert Item Name";
    public Sprite icon = null;

    #endregion

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    { 
        Inventory.instance.Remove(this);
    }
}
