using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DYP;

public class CombatInventory : MonoBehaviour
{
    
    public List<Weapon> weapons;
    private int curWeaponIndex;

    public CombatInventory()
    {    
        weapons = new List<Weapon>();
        curWeaponIndex = 0;   
    }

    public void Initialize(){
        foreach(Weapon weapon in weapons){
            weapon.Deactivate();
        }
        weapons[curWeaponIndex].Activate();
    }

    public void changeWeapon(){
        weapons[curWeaponIndex].Deactivate();

        curWeaponIndex += 1;
        curWeaponIndex %= weapons.Count;

        weapons[curWeaponIndex].Activate();
    }

    public void Attack(){
        weapons[curWeaponIndex].Attack();
    }

    public void Equip(){
        weapons[curWeaponIndex].setIsEquiped(true);      
    }

    public void Unequip(){
        weapons[curWeaponIndex].setIsEquiped(false);
    }

}
