using System.Collections;
using UnityEngine;
using System;   

[System.Serializable]
public class RangedWeapon : Weapon
{
    public float offset;
    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;

    void ShootBullet(){
        GameObject bullet_go = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        Projectile bullet = bullet_go.GetComponent<Projectile>();
        bullet.Move(transform.right);
        Debug.Log("Shooted");
    }

    // overriding method Attack
    public override void Attack(){
        if (timeBtwShots <= 0)
        {
            ShootBullet();
            ResetTimer();
        }
    }

    // ex: Mouse position, player's position
    public virtual Vector3 GetPositionOfTarget(){
        return Vector3.zero;
    }

    // Handles the weapon rotation
    public void SetWeaponAngle(Vector3 difference){
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    public void Update()
    {   
        SetWeaponAngle(GetPositionOfTarget());
        TimerBetweenShots();
    }

}