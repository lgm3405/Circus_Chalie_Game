using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 300f;
    public float speed = default;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigid = default;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        Debug.Assert(playerRigid != null);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            if (jumpCount < 1)
            {
                jumpCount += 1;
                playerRigid.velocity = Vector2.zero;
                playerRigid.AddForce(new Vector2(0, jumpForce));
            }
            else if (Input.GetKeyDown(KeyCode.Space) && 0 < playerRigid.velocity.y)
            {
                playerRigid.velocity = playerRigid.velocity * 0.5f;
            }

            LionAnimation lionanimation_ = new LionAnimation();
            lionanimation_.LionJumpBool();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            jumpCount = 0;
            LionAnimation lionanimation_ = new LionAnimation();
            lionanimation_.LionEnterCheck(isGrounded = true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        LionAnimation lionanimation_ = new LionAnimation();
        lionanimation_.LionEnterCheck(isGrounded = false);
    }
}
