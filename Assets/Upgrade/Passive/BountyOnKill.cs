using UnityEngine;

public class BountyOnKill : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает кол-во золота за убийсво на +1";

    public override void AddUpgrade()
    {
        Tower.instance.BountyOnEnemy += 1;
    }
}