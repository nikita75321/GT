using UnityEngine;

public class IncreaseMaxSlotActive : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Увеличивает кол-во активных улучшений на +1";

    public override void AddUpgrade()
    {
        UpgradeController.instance.IncreaseActiveSlot();
    }
}
