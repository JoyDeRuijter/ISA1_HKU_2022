// Written by Joy de Ruijter
using UnityEngine;
using UnityEngine.UI;

public class MoneyStatUI : StatsUI
{
    #region Variables

    private PlayerStats playerStats;

    #endregion

    private void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        value = playerStats.money.GetStatValue();
        counter = transform.Find("Text").GetComponent<Text>();
        statName = "Money";
    }

    protected override void Update()
    {
        base.Update();
        value = playerStats.money.GetStatValue();
    }
}
