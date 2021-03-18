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
    public Animator camAnim;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // overriding method Attack
    public override void Attack(){
        if (timeBtwShots <= 0)
        {
            GameObject bullet_go = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            Projectile bullet = bullet_go.GetComponent<Projectile>();
            bullet.Move(transform.right);
            Debug.Log("Shooted");
            timeBtwShots = startTimeBtwShots;
        }
    }

    void followMouseCursor(){
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    private void Update()
    {
        // Handles the weapon rotation
        followMouseCursor();

        timeBtwShots -= Time.deltaTime;
    }

}