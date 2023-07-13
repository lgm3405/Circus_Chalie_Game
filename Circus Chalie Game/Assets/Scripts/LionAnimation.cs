using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAnimation : MonoBehaviour
{
    private bool isGrounded = false;
    private Animator animator = default;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Assert(animator != null);
    }

    void Update()
    {
        
    }

    public void LionJumpBool()
    {
        animator.SetBool("Grounded", isGrounded);
    }

    public void LionEnterCheck(bool isGrounded)
    {

    }

}
