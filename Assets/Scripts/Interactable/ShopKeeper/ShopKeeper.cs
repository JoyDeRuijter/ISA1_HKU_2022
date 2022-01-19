// Written by Joy de Ruijter
using UnityEngine;

public class ShopKeeper : Interactable
{
    #region Variables
    
    #endregion

    private void Awake()
    {
        
    }

    protected override void Update()
    {
        base.Update();
        transform.LookAt(player.transform.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
