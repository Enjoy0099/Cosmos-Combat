using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;

    private Vector3 healthBarScale;

    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private GameObject destroyEffect;

    [SerializeField]
    private GameObject hitEffect;

    private DropCollectable dropCollectable;

    private void Awake()
    {
        dropCollectable = GetComponent<DropCollectable>();
    }

    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageResistance = (damageResistance * 6f) / 100f;
        damageAmount -= damageResistance;
        health -= damageAmount;
        if(health <= 0)
        {
            health = 0;
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            if(gameObject.CompareTag(TagManager.ENEMY_TAG))
            {
                GameplayUIController.instance.SetInfoUI(2);
                EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            }
            else if(gameObject.CompareTag(TagManager.METEOR_TAG))
            {
                GameplayUIController.instance.SetInfoUI(3);
            }
            SoundManager.instance.PlayDestorySound();
            dropCollectable.CheckToSpawnCollectable();
            Destroy(gameObject);

        }
        else
        {
            
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            SoundManager.instance.PlayHitSound();

        }
        SetHealthBar();
    }

    void SetHealthBar()
    {
        if (!healthBar)
            return;

        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100f;
        healthBar.transform.localScale = healthBarScale;



    }



}
