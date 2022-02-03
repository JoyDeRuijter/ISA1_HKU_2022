// Written by Joy de Ruijter
using UnityEngine;

[CreateAssetMenu(fileName = "New Mask", menuName = "Interactables/Mask")]
public class MaskItem : Item
{
    #region Variables

    //[SerializeField] private GameObject hairObject;
    public bool intersectsWithHair;
    public Vector3 targetPosition;
    public int disguise = 1;
    public int shopPrice = 100;

    #endregion

    public override void Use()
    {
        base.Use();

        MaskManager.instance.Equip(this);
        RemoveFromInventory();
    }
}
