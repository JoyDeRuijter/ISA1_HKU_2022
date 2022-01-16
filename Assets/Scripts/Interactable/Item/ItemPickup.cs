// Written by Joy de Ruijter
using UnityEngine;

public class ItemPickup : Interactable
{
    #region Variables

    public Item item;

    #endregion

    public override void Interact()
    {
        base.Interact();

        if (item.isEquipped)
            return;

        PickUp();
    }

    private void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
 
        if (!wasPickedUp)
            return;

        Destroy(gameObject);
    }
}
