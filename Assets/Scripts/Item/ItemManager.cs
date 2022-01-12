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
    public List<GameObject> itemObjects = new List<GameObject>();

    #endregion

    private void Start()
    {
        playerManager = PlayerManager.instance;
    }

    public void DropItem(string itemName)
    {
        //Debug.Log("Should drop item now");

        for (int i = 0; i < itemObjects.Count; i++)
        {
            if (itemObjects[i].name == itemName)
            {
                objectToDrop = itemObjects[i];
                break;
            }
        }

        Vector3 dropPosition = new Vector3 (playerManager.player.transform.position.x, playerManager.player.transform.position.y + 1, playerManager.player.transform.position.z);
        GameObject droppedObject = Instantiate(objectToDrop, dropPosition, Quaternion.identity);
        droppedObject.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward * 250);
    }
}
