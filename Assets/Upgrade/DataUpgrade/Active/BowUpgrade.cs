using System;
using UnityEngine;

public class BowUpgrade : Bow
{
    private GameObject target;
    private float cooldown = 1;
    private float tempColldown = 1;
    private Vector3 offsetY = new Vector3(0,6,0);

    public void Upgrade()
    {
        if (cooldown > 0.4f)
        {
            cooldown = (float)Math.Round(cooldown - 0.1f, 1);
        }
        else
        {
            Damage += 3;
        }
    }

    private void Update()
    {
        if (tempColldown > 0)
        {
            tempColldown -= Time.deltaTime;
        }
        else
        {
            tempColldown = cooldown;
            ActiveBow();
        }
    }

    private void ActiveBow()
    {
        try
        {
            target = Tower.instance.GetFirstEnemy();
        }
        catch {target = null;}
        
        if (target != null && Tower.instance.STATE == Tower.State.Live)
        {
            // var arrowClone = PoolManager.instance.Spawn(arrow, transform.position, Quaternion.identity);
            var arrowClone = Instantiate(arrow, transform.position + offsetY, Quaternion.identity);
            arrowClone.GetComponent<Arrow>().SetTarget(target.transform, Damage * (Tower.instance.PhysicDMG / 100));
        }
    }
}