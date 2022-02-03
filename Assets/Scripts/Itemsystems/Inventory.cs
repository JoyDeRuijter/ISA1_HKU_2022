// Written by Joy de Ruijter
using System.Collections;
using UnityEngine;

public class Inventory : ItemSystem
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

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    #endregion

    private void Start()
    {
        capacity = 20;

        if (items != null)
            onItemChangedCallback.Invoke();
    }

    public override bool Add(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Inventory is full!");
            return false;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }

    public override void Remove(Item item)
    { 
        base.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
