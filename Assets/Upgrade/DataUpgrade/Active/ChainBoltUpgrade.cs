using System;
using System.Collections;
using UnityEngine;

public class ChainBoltUpgrade : ChainBolt
{
    private ParticleSystem lightStrike, lightStrikeBounce;
    private GameObject target;
    private float cooldown = 1.5f;
    private float tempColldown = 1.5f;
    // private Vector3 offsetY = new Vector3(0,6,0);

    public void Initialize(ParticleSystem instanceStrike, ParticleSystem instanceStrikeClone)
    {
        lightStrike = instanceStrike;
        lightStrikeBounce = instanceStrikeClone;

        lightStrike.Pause();
        lightStrikeBounce.gameObject.SetActive(false);
    }

    public void Upgrade()
    {
        if (cooldown > 0.8)
        {
            cooldown = (float)Math.Round(cooldown - 0.1f, 1);
        }
        else
        {
            Damage += 5;
            Debug.Log(Damage);
        }
    }

    void Update()
    {
        if (tempColldown > 0)
        {
            tempColldown -= Time.deltaTime;
        }

        else
        {
            tempColldown = cooldown;
            ActiveLightning();
        }
    }

    private void ActiveLightning()
    {
        if (Tower.instance.GetFirstEnemy() != null && Tower.instance.STATE == Tower.State.Live)
        {
            target = Tower.instance.GetFirstEnemy();

            var main = lightStrike.main;
            main.startSpeed = (gameObject.transform.position - target.transform.position).magnitude;
            
            lightStrike.transform.LookAt(target.transform);
            lightStrike.Play();

            if(Tower.instance.enemyList.Count > 1)
            {
                var result = Tower.instance.GetNearstEnemy();
                StartCoroutine(LightStrikeBonce(result.Item1, result.Item2));
            }

            target.GetComponent<Enemy>().ApplyDamage(Damage * (Tower.instance.MagicDMG / 100));
        }
    }

    private IEnumerator LightStrikeBonce(GameObject enemy, float distance)
    {
        lightStrikeBounce.transform.position = target.transform.position;

        var main = lightStrikeBounce.main;
        main.startSpeed = distance;

        lightStrikeBounce.transform.LookAt(enemy.transform);
        lightStrikeBounce.gameObject.SetActive(true);

        enemy.GetComponent<Enemy>().ApplyDamage((int)(Damage * (Tower.instance.MagicDMG / 100) / 2));

        yield return new WaitUntil( () => lightStrikeBounce.isStopped);
        lightStrikeBounce.gameObject.SetActive(false);
    }
}