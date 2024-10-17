using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDmgUp : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает магический урон на +25%";

    public override void AddUpgrade()
    {
        Tower.instance.MagicDMG += 25;
        EventManager.onUIChanged?.Invoke();
    }
}
