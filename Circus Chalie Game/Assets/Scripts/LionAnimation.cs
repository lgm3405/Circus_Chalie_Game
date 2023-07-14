using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAnimation : MonoBehaviour
{
    private Animator animator = default;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Assert(animator != null);
    }

    void Update()
    {
        animator.SetBool("Grounded", GameManager.instance.isGrounded);
    }
}
