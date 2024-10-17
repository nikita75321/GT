using UnityEngine;

public class RegenerationUP : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает регенерацию здоровья на (+5)";

    public override void AddUpgrade()
    {
        Tower.instance.HealthRegeneration += 5;
    }
}