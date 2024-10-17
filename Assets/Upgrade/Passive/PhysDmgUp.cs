using UnityEngine;

public class PhysDmgUp : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает физический урон на +25%";

    public override void AddUpgrade()
    {
        Tower.instance.PhysicDMG += 25;
        EventManager.onUIChanged?.Invoke();
    }
}
