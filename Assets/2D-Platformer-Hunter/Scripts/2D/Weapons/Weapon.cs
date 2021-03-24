using System.Collections;
using UnityEngine;
using System;   

public class Weapon : MonoBehaviour
{

    public float timeBtwShots;
    public float startTimeBtwShots;

    public virtual void Attack(){
        Debug.Log("Attack");
    }

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

 }