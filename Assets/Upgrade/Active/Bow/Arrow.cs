using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int speed = 25;
    private float damage;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed *2);
    }

    public void SetTarget(Transform target, float damage)
    {
        transform.LookAt(target);
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ApplyDamage(damage);
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag(nameof(Plane)))
        {
            Destroy(gameObject);
        }
    }
}
