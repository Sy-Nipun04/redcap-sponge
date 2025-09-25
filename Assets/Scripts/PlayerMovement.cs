using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxcollider;
    public CapsuleCollider2D capsulecollider;
    private float horizontal;
    [SerializeField]private float speed = 7f;
    [SerializeField]private float jumpPower = 12f;
    private bool isFacingRight = true;
    private bool canJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(!onLeftWall() && !onRightWall())
        {
            canJump = true;
        }

        animator.SetBool("grounded", isGrounded());
        
        if(Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.Space) && onLeftWall() && canJump && Input.GetKey(KeyCode.D))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.Space) && onRightWall() && canJump && Input.GetKey(KeyCode.A))
        {
            Jump();
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.3f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onLeftWall()
    {
        RaycastHit2D raycastHitL = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.left, 0.1f, groundLayer);
        return raycastHitL.collider != null;
    }

    private bool onRightWall()
    {
        RaycastHit2D raycastHitR = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.right, 0.1f, groundLayer);
        return raycastHitR.collider != null;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        animator.SetTrigger("jump");
        canJump = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    
}