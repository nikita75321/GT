using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class IncreaseMaxHpOverTime : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает макс. здоровье на 2/с";
    protected int hpOverTime = 0;

    public override void AddUpgrade()
    {
        Tower.instance.HpSec += 2;
    }
}