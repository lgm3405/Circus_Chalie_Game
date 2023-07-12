using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject BackGroundPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 2.5f;
    public float timeBetSpawnMax = 4.5f;
    private float timeBetSpawn;

    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private float xPos = 20f;

    private GameObject[] platforms;
    private int currentIndex = 0;
    private Vector2 poolPosition = new Vector2(0, -25f);
    private float lastSpawnTime;

    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(BackGroundPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        if (lastSpawnTime + timeBetSpawn <= Time.time)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex += 1;

            if (count <= currentIndex)
            {
                currentIndex = 0;
            }
        }
    }
}
