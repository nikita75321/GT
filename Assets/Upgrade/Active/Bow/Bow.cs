using Unity.VisualScripting;
using UnityEngine;

public class Bow : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    [SerializeField] protected GameObject arrow;
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Наносит 10 урона по 1 ближайшему врагу";
    public override float Damage {get => damage; set => damage = value;}
    private float damage = 10;

    public override void AddUpgrade()
    {
        var tower = Tower.instance;
        var bowInstance = tower.GetComponent<BowUpgrade>();

        if (!bowInstance)
        {
            var instance = tower.AddComponent<BowUpgrade>();
            instance.arrow = arrow;
        }
        else
        {
            bowInstance.Upgrade();
        }
    }
}