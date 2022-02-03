// Written by Joy de Ruijter
using UnityEngine;

public class MaskManager : MonoBehaviour
{
    #region Singleton

    public static MaskManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region Variables

    [HideInInspector] public MaskItem currentMask;
    [HideInInspector] public MaskItem oldMask;
    [SerializeField] private GameObject hairObject;

    private Inventory inventory;
    private PlayerManager playerManager;
    private ItemManager itemManager;
    private GameObject player, currentMaskObject;
    private Transform playerHead;

    public delegate void OnMaskChanged(MaskItem newMask);
    public OnMaskChanged onMaskChanged;

    #endregion

    private void Start()
    {
        inventory = Inventory.instance;
        playerManager = PlayerManager.instance;
        player = playerManager.player;
        playerHead = player.transform.Find("RobberModel/Root/Hips/Spine_01/Spine_02/Spine_03/Neck/Head");
        itemManager = ItemManager.instance;
        currentMask = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            Unequip();
    }

    public void Equip(MaskItem newMask)
    {
        if (currentMask != null)
        {
            oldMask = currentMask;
            Unequip();
        }

        if (onMaskChanged != null)
            onMaskChanged.Invoke(newMask);

        if (newMask.intersectsWithHair)
            hairObject.SetActive(false);
        else
            hairObject.SetActive(true);

        for (int i = 0; i < itemManager.maskObjects.Count; i++)
        {
            if (itemManager.maskObjects[i].name == newMask.name)
            {
                currentMaskObject = itemManager.maskObjects[i];
                break;
            }
        }
        
        currentMaskObject = Instantiate(currentMaskObject, newMask.targetPosition, Quaternion.identity, playerHead);
        currentMaskObject.GetComponentInChildren<MeshCollider>().isTrigger = true;
        currentMaskObject.transform.localPosition = newMask.targetPosition;
        currentMaskObject.transform.localRotation = Quaternion.identity;
        currentMaskObject.transform.localScale = new Vector3(100f, 100f, 100f);
        currentMaskObject.GetComponentInChildren<ItemPickup>().cancelOutline = true;
        currentMaskObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        newMask.isEquipped = true;
        currentMask = newMask;
    }

    public void Unequip()
    {
        if (currentMask != null)
        {
            if (currentMask.intersectsWithHair)
                hairObject.SetActive(true);

            currentMask.isEquipped = false;
            oldMask = currentMask;
            inventory.Add(oldMask);

            if (onMaskChanged != null)
                onMaskChanged.Invoke(null);

            currentMaskObject.GetComponentInChildren<ItemPickup>().cancelOutline = false;
  
            Destroy(currentMaskObject);
            currentMask = null;
        }
    }
}
