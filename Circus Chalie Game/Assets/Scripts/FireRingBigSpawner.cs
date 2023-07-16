using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FireRingBigSpawner : MonoBehaviour
{
    public GameObject Fire_Ring_BigPrefab;

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
            GameManager.instance.FireType();
            if (GameManager.instance.fire_type_check == true)
            {
                if (GameManager.instance.fire_type > 40)
                {
                    GameObject fire_ring_big = Instantiate(Fire_Ring_BigPrefab, transform.position, transform.rotation);
                    Destroy(fire_ring_big.gameObject, 10f);
                    GameManager.instance.fire_type_check = false;
                }

                SpawnTime = 0;
            }
        }
    }
}
