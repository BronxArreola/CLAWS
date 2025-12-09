using UnityEngine;

public class PitMonster : MonoBehaviour
{
    public bool goLeft = true;
    public float moveSpeed = 2.0f;

    public float activationRange = 5f;
    public Transform player;

    public Transform groundCheck;      
    public float groundCheckDistance = 1f;
    public LayerMask groundLayer;

    private float direction = -1.0f;
    private Vector3 startingScale;
    private bool isActive = false;

    void Start()
    {
        startingScale = transform.localScale;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (!isActive && distance <= activationRange)
        {
            isActive = true;
        }

        if (!isActive)
            return;

        if (goLeft)
        {
            direction = -1f;
            transform.localScale = startingScale;
        }
        else
        {
            direction = 1f;
            transform.localScale = new Vector3(-startingScale.x, startingScale.y, startingScale.z);
        }

        bool groundAhead = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        if (!groundAhead)
        {
            goLeft = !goLeft;
            return;
        }

        transform.Translate(new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
            goLeft = !goLeft;
    }
}
