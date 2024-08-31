using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    private bool resetJump = false;
    private float speed = 2.5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocityY);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() is true)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, .8f, groundLayer);

        if (hitInfo.collider != null)
        {
            if (!resetJump)
            {
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
