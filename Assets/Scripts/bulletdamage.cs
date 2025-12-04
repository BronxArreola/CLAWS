using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Look for an EnemyHealth on this object or its parent
        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();

        if (enemy != null)
        {
            Debug.Log("Bullet hit enemy: " + other.name);
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
