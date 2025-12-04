using UnityEngine;

public class SideScrollPlayer : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 500.0f;

    Rigidbody2D rb;

    public bool isGrounded = false;
    public bool shouldJump = false;

    Animator animator;
    SpriteRenderer spriteRenderer;

    int groundContacts = 0;  // NEW – track how many ground colliders we’re touching

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);

        // animate!
        if (horizontalInput > 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            shouldJump = true;
        }
    }

    void FixedUpdate()
    {
        if (shouldJump)
        {
            shouldJump = false;
            rb.AddForce(Vector2.up * jumpForce);
            animator.SetBool("isJumping", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts++;
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts = Mathf.Max(0, groundContacts - 1);

            if (groundContacts == 0)
            {
                isGrounded = false;
            }
        }
    }
}
