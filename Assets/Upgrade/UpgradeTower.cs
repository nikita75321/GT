using UnityEngine;

public abstract class UpgradeTower : MonoBehaviour
{
    public virtual UpgradeAttribute UpgradeAttribute{get; set;}
    public virtual string Description {get; set;}
    public virtual int Price {get; set;}
    public virtual float Damage {get; set;}

    public virtual void AddUpgrade()
    {
        Debug.Log("Нет Ничего");
    }
    public virtual void ActivateSkill()
    {
        Debug.Log("Нечего активировать");
    }

    public bool CanBuy()
    {
        if (Tower.instance.Balance >= UpgradeAttribute.price)
        {
            return true;
        }
        return false;
    }
}