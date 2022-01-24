// Written by Joy de Ruijter
using UnityEngine;

public class InventoryUI : ItemSystemUI
{
    #region Variables
    
    private Inventory inventory;
    private InventorySlot[] slots;

    #endregion

    private void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
            shopUI.SetActive(!shopUI.activeSelf);
    }

    public override void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
                slots[i].AddItem(inventory.items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}
