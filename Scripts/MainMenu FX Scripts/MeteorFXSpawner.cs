using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteors;

    private List<GameObject> spawnedMeteors = new List<GameObject>();

    [SerializeField]
    private float minSpawnTime = 7f, maxSpawnTime = 13f;

    private float spawnTimer;

    [SerializeField]
    private float minX = -50f, maxX = 50f;

    private Vector3 spawnPos;

    private int spawnNum;
    private int activateMeteors;

    [SerializeField]
    private bool moveDown;


    private void Start()
    {
        spawnTimer = Time.deltaTime + Random.Range(minSpawnTime, maxSpawnTime);
        SpawnInitialNumberOfMeteors(40);
    }

    private void Update()
    {
        if (Time.time > spawnTimer)
            SpawnMeteorsFromPool();

    }

    void SpawnMeteor()
    {

        spawnNum = Random.Range(1, 4);

        for(int i = 0; i < spawnNum; i++)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

            GameObject newMeteror = Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPos, Quaternion.identity);

            if(moveDown)
                newMeteror.GetComponent<MeteorFXMovement>().moveDown = true;

            newMeteror.transform.SetParent(transform);
        }

        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }




    void SpawnInitialNumberOfMeteors(int spawnNum)
    {

        for(int i = 0; i < spawnNum; i++)
        {
            GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)]);
            newMeteor.transform.SetParent(transform);
            newMeteor.SetActive(false);
            spawnedMeteors.Add(newMeteor);
        }
        
    }


    void SpawnMeteorsFromPool()
    {
        spawnNum = Random.Range(1, 4);
        activateMeteors = 0;

        for(int i = 0; i < spawnedMeteors.Count; i++)
        {
            if(!spawnedMeteors[i].activeInHierarchy)
            {

                spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

                spawnedMeteors[i].SetActive(true);

                spawnedMeteors[i].transform.position = spawnPos;

                if (moveDown)
                    spawnedMeteors[i].GetComponent<MeteorFXMovement>().moveDown = true;

                activateMeteors++;

                if (activateMeteors == spawnNum)
                    break;
            }
        }

        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);

    }



}
