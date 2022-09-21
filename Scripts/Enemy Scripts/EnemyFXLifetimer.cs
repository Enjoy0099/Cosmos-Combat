using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFXLifetimer : MonoBehaviour
{

    [SerializeField]
    private float timer = 3f;

    private void Start()
    {
        Destroy(gameObject, timer);
    }


}
