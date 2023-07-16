using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FireRingSmallSpawner : MonoBehaviour
{
    public GameObject Fire_Ring_SmallPrefab;

    private float SpawnTime = default;
    private float SpawnCoolTime = 3f;

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
            if (GameManager.instance.fire_type_check == true)
            {
                if (GameManager.instance.fire_type <= 40)
                {
                    GameObject fire_ring_small = Instantiate(Fire_Ring_SmallPrefab, transform.position, transform.rotation);
                    Destroy(fire_ring_small.gameObject, 10f);
                    GameManager.instance.fire_type_check = false;
                }

                SpawnTime = 0;
            }
        }
    }
}
