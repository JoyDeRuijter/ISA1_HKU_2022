// Written by Joy de Ruijter
using UnityEngine;
using System.Collections.Generic;

public class ItemSystem : MonoBehaviour
{
    #region Variables

    public int capacity;
    public List<Item> items = new List<Item>();

    #endregion

    public virtual bool Add(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("ItemSystem is full!");
            return false;
        }

        items.Add(item);

        return true;
    }

    public virtual void Remove(Item item)
    { 
        items.Remove(item);
    }
}
