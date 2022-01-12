// Written by Joy de Ruijter
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    #region Variables
    
    private Item item;
    public Image icon;
    public Button removeButton;
    private ItemManager itemManager;

    #endregion

    private void Start()
    {
        itemManager = ItemManager.instance;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        itemManager.DropItem(item.name);
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
            item.Use();
    }
}
