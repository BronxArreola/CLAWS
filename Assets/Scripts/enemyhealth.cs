using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Tell the spawner an enemy died
        if (ExitSpawner.Instance != null)
        {
            ExitSpawner.Instance.RegisterKill();
        }

        Destroy(gameObject);
    }
}
