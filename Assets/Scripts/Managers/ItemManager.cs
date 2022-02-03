// Written by Joy de Ruijter
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Singleton

    public static ItemManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    #region Variables

    private PlayerManager playerManager;
    private GameObject objectToDrop;
    public List<GameObject> valuableObjects = new List<GameObject>();
    public List<GameObject> maskObjects = new List<GameObject>();

    #endregion

    private void Start()
    {
        playerManager = PlayerManager.instance;

        for (int i = 0; i < valuableObjects.Count; i++)
        {
            valuableObjects[i].GetComponent<ItemPickup>().item.isEquipped = false;
        }

        for (int i = 0; i < maskObjects.Count; i++)
        {
            maskObjects[i].GetComponent<ItemPickup>().item.isEquipped = false;
        }
    }

    public void DropObject(string objectName, Item.ItemType itemType)
    {
        if (itemType == Item.ItemType.Valuable)
        {
            for (int i = 0; i < valuableObjects.Count; i++)
            {
                if (valuableObjects[i].name == objectName)
                {
                    objectToDrop = valuableObjects[i];
                    break;
                }
            }
        }
        else if (itemType == Item.ItemType.Mask)
        {
            for (int i = 0; i < maskObjects.Count; i++)
            {
                if (maskObjects[i].name == objectName)
                {
                    objectToDrop = maskObjects[i];
                    break;
                }
            }
        }

        Vector3 dropPosition = new Vector3 (playerManager.player.transform.position.x, playerManager.player.transform.position.y + 1, playerManager.player.transform.position.z);
        GameObject droppedObject = Instantiate(objectToDrop, dropPosition, Quaternion.identity);
        droppedObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
        droppedObject.GetComponentInChildren<MeshCollider>().isTrigger = false;
        droppedObject.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * 250);
        droppedObject.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
