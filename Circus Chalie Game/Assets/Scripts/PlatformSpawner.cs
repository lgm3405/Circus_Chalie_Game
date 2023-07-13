using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Fire_Ring_BigPrefab;

    private GameObject spawner;
    private float SpawnTime = default;
    private float SpawnCoolTime = 4f;
    private float yPos = 0;
    private float xPos = 5f;
    private Vector2 poolPosition = new Vector2(0, -5f);

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        SpawnTime += Time.deltaTime;
        if (SpawnTime >= SpawnCoolTime)
        {
            GameObject fire_ring_big = Instantiate(Fire_Ring_BigPrefab, transform.position, transform.rotation);
            Destroy(fire_ring_big.gameObject, 10f);
            SpawnTime = 0;
        }
    }
}
