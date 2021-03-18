using System.Collections;
using UnityEngine;
using System;   

public class Weapon : MonoBehaviour
{
    public virtual void Attack(){
        Debug.Log("Attack");
    }

    public void Activate(){
        gameObject.SetActive(true);
    }

    public void Deactivate(){
        gameObject.SetActive(false);
    }
}