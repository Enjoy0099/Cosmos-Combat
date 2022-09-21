using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFXLifeTimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 9f;

    private void OnEnable()
    {
        Invoke("DeactivateGameObject", timer) ;
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateGameObject");
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
