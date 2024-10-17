using UnityEngine;
using UnityEngine.UI;

public class Tank : Enemy
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private Slider sliderShield;
    private float atackSpeed;
    private float shield;
    private Enemy enemyTank;

    private Tank()
    {
        MaxHealth = 25;
        AnimationSpeed = 1.5f;
        Bounty = 10;
        Damage = 4;
        atackSpeed = 1f;
        shield = 100;
    }

    protected override void Start()
    {
        enemyTank = gameObject.GetComponent<Enemy>();

        animator.SetBool("Move", true);
        animator.speed = AnimationSpeed;

        base.Start();
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        animator.SetBool("Move", true);
        animator.SetBool("Atack", false);
    }

    private void FixedUpdate()
    {
        if (animator.GetBool("Move"))
        {
            transform.Translate(AnimationSpeed * Time.deltaTime * Vector3.forward.normalized);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Move", false);
            animator.SetBool("Atack", true);
            animator.speed = atackSpeed;
        }
    }

    protected override void EnemyAction()
    {
        Tower.instance.ApplyDamage(Damage, enemyTank);
    }

    public override void ApplyDamage(float damage)
    {
        if(shield >= 0)
        {
            shield -= damage;
        }

        shieldPrefab.SetActive(false);
        base.ApplyDamage(damage);
    }
}