using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform playerTarget;
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public int attackDamage = 10;

    public GameObject projectilePrefab;
    public Transform shotPoint;

    private Animator animator;
    private float nextAttackTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (playerTarget == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerTarget = player.transform;
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
        if (animator != null)
            animator.SetTrigger("Attack");

        if (projectilePrefab != null && shotPoint != null)
            Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);

        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        if (distanceToPlayer <= attackRange)
        {
            PlayerHealth health = playerTarget.GetComponent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(attackDamage);
        }
    }
}
