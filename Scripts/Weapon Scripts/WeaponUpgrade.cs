using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    [SerializeField]
    private WeaponManagerPool[] weapons;


    public void ActivateWeapon(int weaponIndex)
    {
        weapons[weaponIndex].enabled = true;     
    }

}
