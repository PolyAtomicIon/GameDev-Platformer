using System.Collections;
using UnityEngine;
using System;   

public class Weapon : MonoBehaviour, IShootable
{

    // implementing interface IShootable
    public void Shoot(){
        Debug.Log("Shooted");
    }

    void Start(){
        
    }

}