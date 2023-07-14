using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Fire_Ring_BigPrefab;
    public GameObject Fire_Ring_SmallPrefab;

    private float SpawnTime = default;
    private float SpawnCoolTime = 4f;
    private int fire_type;

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
            fire_type = Random.Range(0, 100);
            if (fire_type < 40)
            {
                GameObject fire_ring_small = Instantiate(Fire_Ring_SmallPrefab, transform.position, transform.rotation);
                Destroy(fire_ring_small.gameObject, 10f);
            }
            else
            {
                GameObject fire_ring_big = Instantiate(Fire_Ring_BigPrefab, transform.position, transform.rotation);
                Destroy(fire_ring_big.gameObject, 10f);
            }
            
            SpawnTime = 0;
        }
    }
}
