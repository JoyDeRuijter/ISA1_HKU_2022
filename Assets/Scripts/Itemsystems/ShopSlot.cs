// Written by Joy de Ruijter
using UnityEngine.UI;

public class ShopSlot : ItemSystemSlot
{
    #region Variables

    public Text priceTag;
    private ItemManager itemManager;

    #endregion

    public override void AddItem(Item newItem)
    { 
        base.AddItem(newItem);

        MaskItem newMask = newItem as MaskItem;
        priceTag.text = "$" + newMask.shopPrice;
    }

    public override void ClearSlot()
    { 
        base.ClearSlot();
        priceTag.text = "";
    }

    public void BuyItem()
    {
        if (item != null)
            Shop.instance.Remove(item);
    }

}
