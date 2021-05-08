using System.Collections;
using UnityEngine;
using System;   

[System.Serializable]
public class RangedWeapon : Weapon
{
    public float offset;
    public GameObject projectile;
    public GameObject shotEffect;

    // Add ammo to the weapon
    // chang values during Attack ...

    public override void HandlePhysicsOfAttack(){
        GameObject bullet_go = Instantiate(projectile, attackPos.position, attackPos.rotation);
        Projectile bullet = bullet_go.GetComponent<Projectile>();
        bullet.Move(transform.right);
        Debug.Log("Shooted");
    }

    // ex: Mouse position, player's position
    public virtual Vector3 GetPositionOfTarget(){
        return Vector3.zero;
    }

    // Handles the weapon rotation
    public void SetWeaponAngle(Vector3 difference){
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotZ += offset;

        int dir = 1;
        // if( rotZ < 0 ){
        //     dir = -1;
        // }

        // rotZ = Mathf.Min(45f, Mathf.Abs(rotZ));
        transform.rotation = Quaternion.Euler(0f, 0f, dir * rotZ);
    }

    public void Update()
    {   
        base.Update();
        SetWeaponAngle(GetPositionOfTarget());
    }

}