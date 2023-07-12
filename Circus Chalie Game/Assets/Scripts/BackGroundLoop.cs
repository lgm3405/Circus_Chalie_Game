using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;

    void Start()
    {
        BoxCollider2D backgroundcollider = GetComponent<BoxCollider2D>();
        width = backgroundcollider.size.x;
    }

    void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = transform.position.AddVector(offset);
    }
}
