using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = default;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.isDead) { return; }
        if (GameManager.instance.isGameClear) { return; }
        else
        {
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");
            float xSpeed = xInput * speed * Time.deltaTime;
            float zSpeed = zInput * speed * Time.deltaTime;
            Vector3 newvelocity = new Vector3(xSpeed, 0f, zSpeed);
            transform.Translate(Vector3.right * -xSpeed);
        }
    }
}
