// Written by Joy de Ruijter
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    #region Variables

    private Item item;
    public Image icon;

    #endregion

    public void AddItem(Item newItem)
    { 
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    { 
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void BuyItem()
    {
        if (item != null)
            Shop.instance.Remove(item);
    }

}
