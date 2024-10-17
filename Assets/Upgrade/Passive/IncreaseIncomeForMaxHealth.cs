using UnityEngine;

public class IncreaseIncomeForMaxHealth : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает инком на +3 за -50 макс. здоровья";
    
    public override void AddUpgrade()
    {
        Tower.instance.MoneySec += 3;
        Tower.instance.MaxHealth -= 50;
        EventManager.onUIChanged?.Invoke();
    }
}
