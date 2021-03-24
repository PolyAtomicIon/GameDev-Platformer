using System.Collections;
using UnityEngine;
using System;   

[System.Serializable]
public class EnemyBowWeapon : Weapon
{
    public float offset;

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
    public Transform playerPosition;
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

    void followPlayer(){
        Vector3 difference = new Vector3( playerPosition.position.x, playerPosition.position.y, 0) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    private void Start() {
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    private void Update()
    {
        // Handles the weapon rotation
        followPlayer();

        timeBtwShots -= Time.deltaTime;
    }

}