using UnityEngine;

public class IncreseMaxHealth : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает максимальное здоровье на (+15)";
    
    public override void AddUpgrade()
    {
        Tower.instance.MaxHealth += 15;
        EventManager.onUIChanged?.Invoke();
    }
}
