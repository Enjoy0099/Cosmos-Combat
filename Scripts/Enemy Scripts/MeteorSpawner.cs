using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteors;

    [SerializeField]
    private float minX, maxX;

    private float minSpawnInterval = 8f, maxSpawnInterval = 16f;

    [SerializeField]
    private int minSpawnNumber = 1, maxSpawnNumber = 5;

    private int randSpawnNum;

    private Vector3 randSpawnPos;


    private void Start()
    {
        SpawnMeteors();
        Invoke("SpawnMeteors", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnMeteors()
    {
        randSpawnNum = Random.Range(minSpawnNumber, maxSpawnNumber);

        for(int i = 0; i < randSpawnNum; i++)
        {
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);
        }

        Invoke("SpawnMeteors", Random.Range(minSpawnInterval*1.5f, maxSpawnInterval));

    }





}
