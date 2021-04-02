using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        // on utilise les gameobjects vides pour savoir si le joueur touche le sol
        isGounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);

        animator.SetFloat("Speed", characterVelocity);
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetButtonDown("Jump") && isGounded)
        {
            isJumping = true;
        }
    }

    // méthode pour gerer les movements du player
    void MovePlayer ()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    // méthode pour faire tourner notre perso lors d'un demi-tour
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < - 0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
