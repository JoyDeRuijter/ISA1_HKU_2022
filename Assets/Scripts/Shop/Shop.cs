// Written by Joy de Ruijter
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Singleton

    public static Shop instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Shop found!");
            return;
        }
        instance = this;
    }

    #endregion

    #region Variables

    public int capacity = 10;
    public List<Item> items = new List<Item>();

    public delegate void OnShopChanged();
    public OnShopChanged onShopChangedCallback;

    Inventory inventory;

    #endregion

    private void Start()
    {
        inventory = Inventory.instance;

        if (items != null)
            onShopChangedCallback.Invoke();
    }

    public bool Add(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Shop is full!");
            return false;
        }

        items.Add(item);

        if (onShopChangedCallback != null)
            onShopChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        inventory.Add(item);
        items.Remove(item);

        if (onShopChangedCallback != null)
            onShopChangedCallback.Invoke();
    }
}
