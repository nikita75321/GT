using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Tower : MonoBehaviour
{
    public static Tower instance;
    [HideInInspector] public List<GameObject> enemyList;
    public int MaxHealth{get {return maxHealth;} 
    set 
    { 
        maxHealth = value;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        if (maxHealth <=0)
        {
            currentHealth = 0;
            maxHealth = 0;
            state = State.Death;
        }
    }}
    [SerializeField] private int maxHealth;
    public int CurrentHealth{get {return currentHealth;} set{currentHealth = value;}}
    [SerializeField] private int currentHealth;
    public int HealthRegeneration{get {return healthRegeneration;} set{healthRegeneration = value;}}
    [SerializeField] private int healthRegeneration;
    public int Defense{get {return defense;} set{defense = value;}}
    [SerializeField] private int defense;
    public float Balance{get {return balance;} set{balance = value;}}
    [SerializeField] private float balance;
    public int MoneySec{get {return moneySec;} set{moneySec = value;}}
    [SerializeField] private int moneySec;
    public int HpSec{get {return hpSec;} set{hpSec = value;}}
    [SerializeField] private int hpSec;
    public int Spike{get {return spike;} set{spike = value;}}
    [SerializeField] private int spike;
    public float PhysicDMG{get {return physicDMG;} set{physicDMG = value;}}
    [SerializeField] private float physicDMG;
    public float MagicDMG{get {return magicDMG;} set{magicDMG = value;}}
    [SerializeField] private float magicDMG;
    public float BountyOnEnemy{get {return bountyOnEnemy;} set{bountyOnEnemy = value;}}
    [SerializeField] private float bountyOnEnemy;
    
    public enum State
    {
        Live,
        Death
    }
    public State STATE {get {return state;}}
    private State state;

    private void Awake()
    {
        currentHealth = maxHealth;
        state = State.Live;
        instance = this;
        hpSec = 0;
        spike = 0;
        PhysicDMG = 100;
        MagicDMG = 100;
    }   

    public void Heal(int value)
    {
        currentHealth += value;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void ApplyDamage(float damage, Enemy enemy)
    {
        enemy.ApplyDamage(spike);

        int dealDamage = (int)(damage - Defense);
        
        if (dealDamage < 0)
            dealDamage = 0;

        currentHealth -= dealDamage;

        if (currentHealth < 0) 
        {
            currentHealth = 0;
            state = State.Death;
            Debug.Log("You die");
        }

        EventManager.onUIChanged?.Invoke();
    }

    public void AddEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public GameObject GetFirstEnemy()
    {
        if (enemyList.Count > 0)
            return enemyList[0].transform.Find("Enemy").gameObject;
        return null;
    }

    public (GameObject, float) GetNearstEnemy()
    {
        var nearstEnemy = enemyList[1].transform.Find("Enemy").gameObject;
        var tempDistance = float.MaxValue;
        
        for (int i = 1; i < enemyList.Count; i++)
        {
            var distance = Vector3.Distance(enemyList[0].transform.Find("Enemy").position, 
                                            enemyList[i].transform.Find("Enemy").position);
            if (distance < tempDistance)
            {
                tempDistance = distance;
                nearstEnemy = enemyList[i].transform.Find("Enemy").gameObject;
            }
        }
        return (nearstEnemy, tempDistance);
    }

    public GameObject GetRandomEnemy()
    {
        return enemyList[(int)Random.Range(0f, enemyList.Count - 1f)];
    }
    
    public void RemoveEnemy(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }
}