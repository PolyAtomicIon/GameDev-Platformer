using System.Collections;
using UnityEngine;
using System;   

[System.Serializable]
public class HeroBowWeapon : RangedWeapon
{
    public override Vector3 GetPositionOfTarget(){
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        return difference;
    }
}