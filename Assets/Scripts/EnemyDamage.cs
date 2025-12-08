using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1;         
    public float damageCooldown = 1f;     
    private float nextDamageTime = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Only damage if cooldown is ready
            if (Time.time >= nextDamageTime)
            {
                PlayerHealth player = other.GetComponent<PlayerHealth>();

                if (player != null)
                {
                    player.TakeDamage(damageAmount);
                    nextDamageTime = Time.time + damageCooldown;
                }
            }
        }
    }
}