using System.Collections;
using UnityEngine;
using System;   

public class Weapon : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform attackPos;

    public void Activate(){
        gameObject.SetActive(true);
    }

    public void Deactivate(){
        gameObject.SetActive(false);
    }
    
    public void ResetTimer(){
        timeBtwShots = startTimeBtwShots;
    }

    public void TimerBetweenShots(){
        timeBtwShots -= Time.deltaTime;
    }

    // ex: shoot a bullet, check for collisions
    public virtual void HandlePhysicsOfAttack(){
        Debug.Log("handling physics of attack:)");
    }

    public bool Attack()
    {
        if (timeBtwShots <= 0)
        {
            HandlePhysicsOfAttack();
            ResetTimer();
            return true;
            // Activate SOUND
            // Activate VFX
            // Activate Animation
            // Ammo modification: decrease number of bullets -> RangedWeopon
            // Combo hits -> MeleeWeapon
        }
        return false;
    }
    
    public void Update()
    {   
        TimerBetweenShots();
    }


 }