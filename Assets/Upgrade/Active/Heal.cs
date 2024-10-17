using UnityEngine;

public class Heal : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Востанавливает 50хп";
    
    public override void AddUpgrade()
    {
        Tower.instance.Heal(50);
    } 
}
