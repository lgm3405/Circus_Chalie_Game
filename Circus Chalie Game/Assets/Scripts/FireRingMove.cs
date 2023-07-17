using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.isGameOver == false && GameManager.instance.isGameClear == false)
        {
            transform.Translate(Vector3.left * GameManager.instance.speed * Time.deltaTime);
        }
    }
}
