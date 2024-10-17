using Unity.VisualScripting;
using UnityEngine;

public class ChainBolt : UpgradeTower
{
    [SerializeField] private UpgradeAttribute upgradeAttribute;
    [SerializeField] private ParticleSystem lightningPartical;
    
    public override UpgradeAttribute UpgradeAttribute { get => upgradeAttribute; }
    public override int Price {get => UpgradeAttribute.price;}
    public override string Description {get => description;}
    private string description = "Наносит 10 урона , прыгая по 2 врагам (5 урона)";
    public override float Damage {get => damage; set => damage = value;}
    private float damage = 10;
    
    public override void AddUpgrade()
    {
        var tower = Tower.instance;
        var chainBoltInstance =  tower.GetComponent<ChainBoltUpgrade>();

        if (!tower.GetComponent<ChainBoltUpgrade>())
        {
            chainBoltInstance = tower.AddComponent<ChainBoltUpgrade>();
            var lightStrike = Instantiate(lightningPartical, Tower.instance.transform);
            var lightStrikeClone = Instantiate(lightningPartical, Tower.instance.transform);
            chainBoltInstance.Initialize(lightStrike, lightStrikeClone);
        }
        else
        {
            chainBoltInstance.Upgrade();
        }
    }
}