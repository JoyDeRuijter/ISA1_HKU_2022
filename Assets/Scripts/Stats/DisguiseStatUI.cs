// Written by Joy de Ruijter
using UnityEngine;
using UnityEngine.UI;

public class DisguiseStatUI : StatsUI
{
    #region Variables

    private PlayerStats playerStats;

    #endregion

    private void Start()
    {
        playerStats = playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        value = playerStats.disguise.GetStatValue();
        counter = transform.Find("Text").GetComponent<Text>();
        statName = "Disguise";
    }

    protected override void Update()
    {
        base.Update();
        value = playerStats.disguise.GetStatValue();
    }
}
