using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPositionEnum
{
    Up,
    Down,
    Left,
    Right
}

public class ShipFXSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ships;

    private List<GameObject> spawnedShips = new List<GameObject>();

    public SpawnPositionEnum spawnPosEnum;

    [SerializeField]
    private float minSpawnTime = 5f, maxSpawnTime = 10f;

    private float spawnTimer;

    private bool shipSpawned;

    private Vector3 spawnPos;

    [SerializeField]
    private float minX = -50f, maxX = 50f;

    [SerializeField]
    private float minY = -27f, maxY = 27f;


    private void Start()
    {
        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }


    private void Update()
    {
        if(Time.time > spawnTimer)
        {
            SpawnShip();
        }
    }


    void SpawnShip()
    {
        shipSpawned = false;

        for(int i = 0; i < spawnedShips.Count; i++)
        {
            if(!spawnedShips[i].activeInHierarchy)
            {
                ActivateShip(spawnedShips[i], false);
                shipSpawned = true;
            }
        }

        if(!shipSpawned)
        {
            GameObject newShip = Instantiate(ships[Random.Range(0, ships.Length)]);
            ActivateShip(newShip, true);
        }

        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);

    }

    void ActivateShip(GameObject ship, bool addToList)
    {
        ship.SetActive(true);
        ship.transform.SetParent(transform);

        if(spawnPosEnum == SpawnPositionEnum.Up)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<SpaceShipFXMovement>().SetMovement(true, false, true);
        }

        else if (spawnPosEnum == SpawnPositionEnum.Down)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<SpaceShipFXMovement>().SetMovement(true, false, false);
        }

        else if (spawnPosEnum == SpawnPositionEnum.Left)
        {
            spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<SpaceShipFXMovement>().SetMovement(false, true, false);
        }

        else if (spawnPosEnum == SpawnPositionEnum.Right)
        {
            spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);
            ship.transform.position = spawnPos;
            ship.GetComponent<SpaceShipFXMovement>().SetMovement(false, true, true);
        }


        if(addToList)
        {
            spawnedShips.Add(ship);
        }



    }




}
