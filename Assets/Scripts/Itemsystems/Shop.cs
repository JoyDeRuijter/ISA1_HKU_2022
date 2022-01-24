// Written by Joy de Ruijter
using System.Collections;
using UnityEngine;

public class Shop : ItemSystem
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

    private Inventory inventory;
    private PlayerManager playerManager;
    private Stat playerMoney;
    [SerializeField] private ParticleSystem moneyParticle;
    [SerializeField] private GameObject popUp;

    public delegate void OnShopChanged();
    public OnShopChanged onShopChangedCallback;

    #endregion

    private void Start()
    {
        inventory = Inventory.instance;
        playerManager = PlayerManager.instance;
        playerMoney = playerManager.player.gameObject.GetComponent<PlayerStats>().money;
        capacity = 10;

        if (items != null)
            onShopChangedCallback.Invoke();
    }

    public override bool Add(Item item)
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

    public override void Remove(Item item)
    {
        MaskItem mask = item as MaskItem;
        if (mask.shopPrice <= playerMoney.GetStatValue())
        {
            playerMoney.SubtractValue(mask.shopPrice);
            inventory.Add(item);
            moneyParticle.Play();
            base.Remove(item);

            if (onShopChangedCallback != null)
                onShopChangedCallback.Invoke();
            
        }
        else
        {
            StartCoroutine(ShowPopup(1f));
            Debug.Log("Not enough money to buy this mask");
        }
    }

    private IEnumerator ShowPopup(float showTime)
    {
        popUp.SetActive(true);
        yield return new WaitForSeconds(showTime);
        popUp.SetActive(false);
    }
}
