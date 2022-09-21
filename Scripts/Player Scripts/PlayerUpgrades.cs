using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField]
    private WeaponUpgrade weaponUpgrade;

    private Collectable collectable;


    void DestroyCollectable(Collectable coll)
    {
        if (coll.type != CollectableType.Health)
            Destroy(coll.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {

            collectable = collision.GetComponent<Collectable>();

            if(collectable.type == CollectableType.Blaster1)
            {
                weaponUpgrade.ActivateWeapon(0);
            }

            if (collectable.type == CollectableType.Blaster2)
            {
                weaponUpgrade.ActivateWeapon(1);
            }

            if (collectable.type == CollectableType.Missile)
            {
                weaponUpgrade.ActivateWeapon(2);
            }

            if (collectable.type == CollectableType.Rocket)
            {
                weaponUpgrade.ActivateWeapon(3);
            }

            DestroyCollectable(collectable);
        }
    }
}
