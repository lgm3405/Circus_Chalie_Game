using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingMove : MonoBehaviour
{
    public float speed = 8f;

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
