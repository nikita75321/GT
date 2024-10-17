using System.Collections.Generic;
using UnityEngine;

public class ActiveSkills : MonoBehaviour
{
    public List<UpgradeTower> upgradeList;

    public void AddSkil(UpgradeTower upgrade)
    {
        upgradeList.Add(upgrade);
        upgrade.ActivateSkill();
    }
}
