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
    }

    public void ChangeWeapon(){
        weapons[curWeaponIndex].Deactivate();

        curWeaponIndex += 1;
        curWeaponIndex %= weapons.Count;

        weapons[curWeaponIndex].Activate();
    }

    public void Attack(){
        weapons[curWeaponIndex].Attack();
    }

    
    public void AbilityAttack(){
        abilities[curWeaponIndex].Attack();
    }

}
