using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;
    public Transform player; // Assign the player's Transform in the Inspector

    private Rigidbody2D rb;
    private float lastAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            // Find player by tag if not assigned in Inspector
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player not found! Ensure player has 'Player' tag or assign manually.");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        // Calculate direction to player
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // Move towards player
        rb.linearVelocity = directionToPlayer * moveSpeed;

        // Check if within attack range and cooldown allows
        if (Vector2.Distance(transform.position, player.position) <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        // Implement attack logic here
        // For example, deal damage to the player
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        Debug.Log("Boss attacks!");
        // You could also trigger an attack animation here
    }

    // Optional: Visualize attack range in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}