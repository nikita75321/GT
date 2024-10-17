using UnityEngine;

public class Defense : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает броню на +2";


    public override void AddUpgrade()
    {
        Tower.instance.Defense += 2;
        EventManager.onUIChanged?.Invoke();
    }
}