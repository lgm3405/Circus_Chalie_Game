using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource backgroundMusic = default;

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        Debug.Assert(backgroundMusic != null);
    }

    void Update()
    {
        if (GameManager.instance.isGameOver == true)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
