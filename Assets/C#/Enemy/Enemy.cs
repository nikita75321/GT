using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public abstract class Enemy : MonoBehaviour , IDamageable
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text textHP;
    private int health, maxHealthTemp;
    private float damageTemp;
    public virtual int MaxHealth {get; set;}
    public virtual int Bounty {get; set;}
    public virtual float Damage {get; set;}
    public virtual float AnimationSpeed {get; set;}

    private void Awake()
    {
        maxHealthTemp = MaxHealth;
        damageTemp = Damage;
        health = MaxHealth;

        textHP.text = $"{health}/{MaxHealth}";
    }

    protected virtual void OnEnable()
    {
        var difficult = TimeManager.instance.GetDifficult();

        MaxHealth = (int)(maxHealthTemp * difficult);
        Damage = (int)(damageTemp * difficult);

        health = MaxHealth;
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;
        textHP.text = $"{health}/{MaxHealth}";
        RotateToTarget();
    }

    protected virtual void Start()
    {
        RotateToTarget();
    }

    protected virtual void EnemyAction()
    {
        Debug.Log("Нечего делать");
    }

    private void RotateToTarget()
    {
        transform.LookAt(Tower.instance.transform.position);
    }

    public virtual void ApplyDamage(float damage)
    {
        var tower = Tower.instance;
        health -= (int)damage;
        slider.value -= damage;
        textHP.text = $"{health}/{MaxHealth}";
        
        if (health <= 0)
        {
            tower.Balance += Bounty + tower.BountyOnEnemy;
            tower.RemoveEnemy(transform.parent.gameObject);
            EventManager.onEnemyDead?.Invoke(transform.position, Bounty + tower.BountyOnEnemy);
            PoolManager.instance.Despawn(transform.parent.gameObject);
            EventManager.onUIChanged?.Invoke();
        }
    }
}