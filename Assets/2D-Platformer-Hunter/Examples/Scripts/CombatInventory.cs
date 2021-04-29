using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DYP;

public class CombatInventory : MonoBehaviour
{
    
    public List<Weapon> weapons;
    public List<Weapon> abilities;
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
        if( abilities[curWeaponIndex] )
            abilities[curWeaponIndex].Activate();
    }

    public void ChangeWeapon(){

        if( abilities[curWeaponIndex] )
            abilities[curWeaponIndex].Deactivate();
        weapons[curWeaponIndex].Deactivate();

        curWeaponIndex += 1;
        curWeaponIndex %= weapons.Count;
        
        if( abilities[curWeaponIndex] )
            abilities[curWeaponIndex].Activate();
        weapons[curWeaponIndex].Activate();
    }

    public void Attack(){
        weapons[curWeaponIndex].Attack();
    }

    
    public bool AbilityAttack(){
        return abilities[curWeaponIndex].Attack();
    }

}
