// Written by Joy de Ruijter
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Variables
    
    Inventory inventory;
    public Transform itemsParent;
    public GameObject inventoryUI;

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
            inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    private void UpdateUI()
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
