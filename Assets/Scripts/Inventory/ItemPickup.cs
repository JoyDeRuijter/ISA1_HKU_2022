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

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picked up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (!wasPickedUp)
            return;

        Destroy(gameObject);
    }
}
