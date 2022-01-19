// Written by Joy de Ruijter
using UnityEngine;

public class ShopKeeper : Interactable
{
    #region Variables

    [SerializeField] private GameObject shopUI;

    #endregion

    protected override void Update()
    {
        base.Update();

        transform.LookAt(player.transform.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    public override void Interact()
    {
        base.Interact();
        EnableShop();
        ConstrainPlayer();   
    }

    private void EnableShop()
    { 
        shopUI.SetActive(!shopUI.activeSelf);
    }

    private void ConstrainPlayer()
    {
        if (shopUI.activeSelf)
            playerRB.constraints = RigidbodyConstraints.FreezePosition;
        else
        {
            playerRB.constraints = RigidbodyConstraints.None;
            playerRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }

}
