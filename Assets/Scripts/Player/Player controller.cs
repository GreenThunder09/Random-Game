using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 13f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isJumping = false;
    public bool isGrounded = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input 
        horizontalInput = Input.GetAxisRaw("Horizontal");
        
       if (horizontalInput != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && !isJumping && isGrounded)
        {
            isJumping = true;
            isGrounded = false;

        }

        FlipPlayerSprite();
    }

    // FixedUpdate is called at a fixed interval and is used for physics operations
    void FixedUpdate()
    { 
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
            
          
        }
    }

    // Check for collisions to reset jump ability
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }
    }

    void FlipPlayerSprite()
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
    }
}

