using UnityEngine;

public class IncreaseMaxSlotPasive : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает кол-во пасивных улучшений на +1";

    public override void AddUpgrade()
    {
        UpgradeController.instance.IncreasePassiveSlot();
    }
}
