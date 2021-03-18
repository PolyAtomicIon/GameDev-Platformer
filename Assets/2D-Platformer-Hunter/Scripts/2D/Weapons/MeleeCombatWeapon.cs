using System.Collections;
using UnityEngine;
using System;   

[System.Serializable]
public class MeleeCombatWeapon : Weapon
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public override void Attack(){
        Debug.Log("Melee attack");
    }

    private void Update()
    {
        timeBtwShots -= Time.deltaTime;
    }

}