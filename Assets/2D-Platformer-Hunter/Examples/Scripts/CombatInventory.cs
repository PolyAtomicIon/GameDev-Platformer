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

    void DeactivateWeapon(int index){
        if( abilities[index] )
            abilities[index].Deactivate();
        if( weapons[index] )
            weapons[index].Deactivate();
    }

    void ActivateWeapon(int index){
        if( abilities[index] )
            abilities[index].Activate();
        if( weapons[index] )
            weapons[index].Activate();
    }

    public void Initialize(){
        for(int i=0; i<weapons.Countl; i++)
            DeactivateWeapon(i);

        ActivateWeapon(curWeaponIndex);
    }

    public void ChangeWeapon(){

        DeactivateWeapon(curWeaponIndex);

        curWeaponIndex += 1;
        curWeaponIndex %= weapons.Count;

        ActivateWeapon(curWeaponIndex);

    }

    public void Attack(){
        weapons[curWeaponIndex].Attack();
    }

    
    public bool AbilityAttack(){
        return abilities[curWeaponIndex].Attack();
    }

}
