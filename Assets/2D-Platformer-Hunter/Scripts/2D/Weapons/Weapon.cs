using System.Collections;
using UnityEngine;
using System;   

public class Weapon : MonoBehaviour
{
    public bool equiped = true;

    public virtual void Attack(){
        Debug.Log("Attack");
    }

    public void Activate(){
        gameObject.SetActive(true);
    }

    public void Deactivate(){
        gameObject.SetActive(false);
    }

    public void setIsEquiped(bool value) {
        equiped = value;
    }

    public bool isEquiped(){
        return equiped;
    }
}