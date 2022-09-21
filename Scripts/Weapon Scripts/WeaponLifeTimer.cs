using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLifeTimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 3f;

    /*private void Start()
    {
        Destroy(gameObject, timer);
    }*/

    private void OnEnable()
    {
        Invoke("DeactivateProjectile", timer);
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateProjectile");

    }

    void DeactivateProjectile() 
    {
        if(gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
