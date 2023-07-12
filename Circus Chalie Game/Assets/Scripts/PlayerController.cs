using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Debug.Assert(playerRigid != null);
        Debug.Assert(animator != null);
    }
    void Update()
    {
        if (isDead) { return; }

        if (Input.GetMouseButtonDown(0) && jumpCount < 3)
        {
            if (jumpCount < 3)
            {
                jumpCount += 1;
                playerRigid.velocity = Vector2.zero;
                playerRigid.AddForce(new Vector2(0, jumpForce));
            }
            else if (Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
            {
                playerRigid.velocity = playerRigid.velocity * 1f;
            }
        }

        animator.SetBool("Ground", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
