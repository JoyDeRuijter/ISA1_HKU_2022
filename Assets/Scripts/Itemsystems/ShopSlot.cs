// Written by Joy de Ruijter

public class ShopSlot : ItemSystemSlot
{
    public virtual void AddItem(Item newItem)
    { 
        base.AddItem(newItem);
    }

    public override void ClearSlot()
    { 
        base.ClearSlot();
    }

    public void BuyItem()
    {
        if (item != null)
            Shop.instance.Remove(item);
    }

}
