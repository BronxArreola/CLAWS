using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform playerTarget; // Assign in Inspector or find by tag
    public float attackRange = 5f;
    public float attackCooldown = 2f; // Time between attacks
    public GameObject projectilePrefab; // For ranged attacks
    public Transform shotPoint; // Where projectile spawns

    private Animator animator;
    private float nextAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        // If not assigned in Inspector, find player by tag
        if (playerTarget == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTarget = player.transform;
            }
        }
    }

    void Update()
    {
        if (playerTarget == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        if (distanceToPlayer <= attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void Attack()
    {
        // Example: Play an attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // Assumes you have an "Attack" trigger in your Animator
        }

        // Example: Ranged attack
        if (projectilePrefab != null && shotPoint != null)
        {
            Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);
        }

        // Add other attack logic here (e.g., melee damage, special abilities)
    }
}