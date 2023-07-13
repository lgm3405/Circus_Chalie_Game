using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;
    private float width_add;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
        width_add = width * 2.5f;
    }
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x <= -width_add)
        {
            Reposition();
        }
    }

    //   두 벡터를 더한다.
    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 6f, 0);
        //transform.position = (Vector2)transform.position + offset;
        transform.position = transform.position.AddVector(offset);
    }
}
