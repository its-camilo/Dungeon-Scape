using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    private bool resetJump = false;
    private float speed = 2.5f;
    private bool grounded = false;
    private PlayerAnimation playerAnim;
    private SpriteRenderer playerSprite;
    private SpriteRenderer swordArcSprite;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(0) && isGrounded())
        {
            playerAnim.Attack();
        }
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        grounded = isGrounded();
        Flip(move);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() is true)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnim.Jump(true);
        }
        
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocityY);
        playerAnim.Move(move);
    }
    
    void Flip(float move)
    {
        if (move > 0)
        {
            playerSprite.flipX = false;
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;
            
            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordArcSprite.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            playerSprite.flipX = true;
            swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;
            
            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            swordArcSprite.transform.localPosition = newPos;
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        if (hitInfo.collider != null)
        {
            if (!resetJump)
            {
                playerAnim.Jump(false);
                return true;
            }
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(.1f);
        resetJump = false;
    }
}
