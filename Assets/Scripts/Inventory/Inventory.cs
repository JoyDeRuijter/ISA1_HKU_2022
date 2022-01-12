// Written by Joy de Ruijter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    #region Variables

    public int capacity = 15;
    public List<Item> items = new List<Item>(); 

    public delegate void ItemChangedCallback();
    public ItemChangedCallback itemChangedCallback;

    #endregion

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= capacity)
            {
                Debug.Log("Inventory is full!");
                return false;
            }

            items.Add(item);

            if (itemChangedCallback != null)
                itemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    { 
        items.Remove(item);

        if (itemChangedCallback != null)
            itemChangedCallback.Invoke();
    }
}
