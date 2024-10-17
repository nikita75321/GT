using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private AnimationCurve curveY;
    private float time;
    private float totalTime = 3;
    private float damage;
    private Enemy enemy;
    
    public void Init(Enemy enemy, float damage)
    {
        this.enemy = enemy;
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Tower.instance.ApplyDamage(damage, enemy);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        transform.LookAt(Tower.instance.transform);
    }

    private void Update()
    {
        time += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, curveY.Evaluate(time) * 5, transform.position.z);
        transform.Translate(Vector3.forward * Time.deltaTime * 6);

        if (time >= totalTime)
        {
            time = 0;
        }
    }
}