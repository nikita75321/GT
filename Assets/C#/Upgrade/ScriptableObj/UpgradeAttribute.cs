using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Upgrade", fileName = "UpgradeName")]
public class UpgradeAttribute : ScriptableObject
{
    public Sprite icon;
    public UpgradeType upgradeType;
    public string upgradeName;
    public int price;
}

public enum UpgradeType
{
    Active,
    Passive
}