// Written by Joy de Ruijter
using UnityEngine.UI;

public class InventorySlot : ItemSystemSlot
{
    #region Variables

    public Button removeButton;
    private ItemManager itemManager;

    #endregion

    private void Start()
    {
        itemManager = ItemManager.instance;
    }

    public override void AddItem(Item newItem)
    {
        base.AddItem(newItem);
        removeButton.interactable = true;
    }

    public override void ClearSlot()
    {
        base.ClearSlot();
        removeButton.interactable = false;    
    }

    public void OnRemoveButton()
    {
        itemManager.DropObject(item.name, item.itemType);
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
            item.Use();
    }
}
