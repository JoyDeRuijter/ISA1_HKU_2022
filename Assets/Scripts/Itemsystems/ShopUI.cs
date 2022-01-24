// Written by Joy de Ruijter
using UnityEngine;

public class ShopUI : ItemSystemUI
{
    #region Variables

    private Shop shop;
    private ShopSlot[] slots;

    #endregion

    private void Start()
    {
        shop = Shop.instance;
        shop.onShopChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<ShopSlot>();
    }

    public override void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < shop.items.Count)
                slots[i].AddItem(shop.items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}
