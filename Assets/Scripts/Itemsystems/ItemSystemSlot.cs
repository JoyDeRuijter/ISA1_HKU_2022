// Written by Joy de Ruijter
using UnityEngine;
using UnityEngine.UI;

public class ItemSystemSlot : MonoBehaviour
{
    #region Variables

    public Item item;
    public Image icon;

    #endregion

    public virtual void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public virtual void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
