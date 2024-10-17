using UnityEngine;

public class Range : Enemy
{
    [SerializeField] private Animator animator;
    [SerializeField] protected GameObject bullet;
    private float atackSpeed;
    private float distanceToTower;
    private Enemy enemyRange;

    protected Range()
    {
        MaxHealth = 20;
        AnimationSpeed = 11.5f;
        Bounty = 5;
        Damage = 7;
        atackSpeed = 0.15f;
    }

    protected override void Start()
    {
        enemyRange = gameObject.GetComponent<Enemy>();

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
        distanceToTower = Vector3.Distance(transform.position, Tower.instance.transform.position);

        if (distanceToTower > 20)
        {
            transform.Translate(AnimationSpeed * Time.deltaTime * Vector3.forward.normalized);
        }
        else
        {
            animator.speed = atackSpeed;
            animator.SetBool("Move", false);
            animator.SetBool("Atack", true);
        }
    }
    
    protected override void EnemyAction()
    {
        DealDamage();
    }

    private void DealDamage()
    {
        var cloneBullet = Instantiate(bullet, transform.position + new Vector3(0, 4.5f, 0), Quaternion.identity);
        Physics.IgnoreCollision(cloneBullet.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
        cloneBullet.GetComponent<Bullet>().Init(enemyRange, Damage);
    }
}