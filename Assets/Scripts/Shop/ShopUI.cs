// Written by Joy de Ruijter
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    #region Variables

    Shop shop;
    public Transform itemsParent;
    public GameObject shopUI;

    private ShopSlot[] slots;

    #endregion

    private void Start()
    {
        shop = Shop.instance;
        shop.onShopChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<ShopSlot>();
    }

    private void UpdateUI()
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
