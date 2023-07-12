using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
