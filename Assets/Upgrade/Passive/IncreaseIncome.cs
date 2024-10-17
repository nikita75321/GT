using UnityEngine;

public class IncreaseIncome : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает инком на +1";
    
    public override void AddUpgrade()
    {
        Tower.instance.MoneySec += 1;
        EventManager.onUIChanged?.Invoke();
    }
}
