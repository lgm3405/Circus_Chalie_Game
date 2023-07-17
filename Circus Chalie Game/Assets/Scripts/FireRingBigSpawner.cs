using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FireRingBigSpawner : MonoBehaviour
{
    public GameObject Fire_Ring_BigPrefab;

    private float SpawnTime = default;

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
        if (SpawnTime >= GameManager.instance.spawn_cooltime)
        {
            GameManager.instance.FireType();
            if (GameManager.instance.fire_type_check == true)
            {
                if (GameManager.instance.fire_type > 30)
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
