using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private float playerMaxHealth = 100f;

    private float playerHealth;

    [SerializeField]
    private GameObject playerExplosionFX;

    [SerializeField]
    private GameObject playerDamageFX;

    private Collectable collectable;

    private Slider playerHealthSlider;



    private void Awake()
    {
        playerHealthSlider = GameObject.FindWithTag
            (TagManager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();

        playerHealth = playerMaxHealth;
        
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        float damageresistance = 0f;
        damageresistance = (damageAmount * 19f)/100f;
        damageAmount -= damageresistance;

        playerHealth -= damageAmount;
        playerHealthSlider.value = playerHealth;

        if(playerHealth <= 0)
        {

            playerHealth = 0;
            Instantiate(playerExplosionFX, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDestorySound();

            GameOverUIController.instance.OpenGameOverPanel();
            
            Destroy(gameObject);
        
        }
        else
        {

            Instantiate(playerDamageFX, transform.position, Quaternion.identity);
            SoundManager.instance.PlayHitSound();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {

            collectable = collision.GetComponent<Collectable>();

            if(collectable.type == CollectableType.Health)
            {
                playerHealth += collectable.healthValue;
                playerHealthSlider.value = playerHealth;

                if (playerHealth > playerMaxHealth)
                    playerHealth = playerMaxHealth;

                Destroy(collision.gameObject);
            }


        }





        if(collision.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20f, 40f));
            Destroy(collision.gameObject);
        }



    }


}
