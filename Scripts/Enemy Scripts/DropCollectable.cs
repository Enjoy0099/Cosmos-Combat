using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectable : MonoBehaviour
{

    [SerializeField]
    private GameObject[] collectable;

    public void CheckToSpawnCollectable()
    {

        if(Random.Range(0,2) > 0)
        {
            Instantiate(collectable[Random.Range(0, collectable.Length)], 
                        transform.position, Quaternion.identity);
        }

    }





}
