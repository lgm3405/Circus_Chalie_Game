using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 270f;
    public float speed = default;
    public AudioClip DeathClip;

    private int jumpCount = 0;
    private Rigidbody2D playerRigid = default;
    private AudioSource playerAudio = default;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        Debug.Assert(playerRigid != null);
        Debug.Assert(playerAudio != null);
    }
    void Update()
    {
        if (GameManager.instance.isDead) { return; }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            if (jumpCount < 1)
            {
                jumpCount += 1;
                playerRigid.velocity = Vector2.zero;
                playerRigid.AddForce(new Vector2(0, jumpForce));
                playerAudio.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && 0 < playerRigid.velocity.y)
            {
                playerRigid.velocity = playerRigid.velocity * 0.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hit") && GameManager.instance.isDead == false)
        {
            Die();
        }
        if (collision.tag.Equals("Bonus") && GameManager.instance.isDead == false)
        {
            GameManager.instance.AddBonus(200);
            collision.gameObject.SetActive(false);
            GameManager.instance.BonusSound();

        }
        if (collision.tag.Equals("Score") && GameManager.instance.isDead == false)
        {
            GameManager.instance.AddScore(100);
        }
    }

    private void Die()
    {
        GameManager.instance.isDead = true;
        playerRigid.velocity = Vector2.zero;
        GameManager.instance.OnPlayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            GameManager.instance.isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameManager.instance.isGrounded = false;
    }
}
