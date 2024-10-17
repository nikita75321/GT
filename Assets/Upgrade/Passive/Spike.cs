using UnityEngine;

public class Spike : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Возвращает 10 урона атакующему";

    public override void AddUpgrade()
    {
        Tower.instance.Spike += 10;
    }
}