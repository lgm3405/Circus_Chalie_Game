using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlieAnimation : MonoBehaviour
{
    private Animator animator = default;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Assert(animator != null);
    }

    void Update()
    {
        if (GameManager.instance.isDead == true)
        {
            animator.SetTrigger("Die");
        }
        if (GameManager.instance.isGameClear == true)
        {
            animator.SetTrigger("Clear");
        }
    }
}
