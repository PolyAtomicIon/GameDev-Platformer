using System.Collections;
using UnityEngine;
using System;   

public class Weapon : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform attackPos;
    public AudioSource attackSound;

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

    public void PlayAudio(){
        if( attackSound )
            attackSound.Play();
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
            PlayAudio();
            // Activate SOUND
            // Activate VFX
            // Activate Animation
            // Ammo modification: decrease number of bullets -> RangedWeopon
            return true;
        }
        return false;
    }
    
    public void Update()
    {   
        TimerBetweenShots();
    }


 }