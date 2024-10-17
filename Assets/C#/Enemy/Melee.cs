using UnityEngine;

public class Melee : Enemy
{
    [SerializeField] private Animator animator;
    private float atackSpeed;
    private Enemy enemyMelee;

    private Melee()
    {
        MaxHealth = 40;
        AnimationSpeed = 1.5f;
        Bounty = 10;
        Damage = 4;
        atackSpeed = 1f;
    }

    protected override void Start()
    {
        enemyMelee = gameObject.GetComponent<Enemy>();

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
        Tower.instance.ApplyDamage(Damage, enemyMelee);
    }
}