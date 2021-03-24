using System.Collections;
using UnityEngine;

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

    Vector3 positionError;

    // overriding method Attack
    public override void Attack(){
        if( !isEquiped() )
            return;

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
        if( !isEquiped() )
            return;

        Vector3 difference = playerPosition.position + positionError - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    private void Start() {
        setIsEquiped(false);
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    private void Update()
    {
        // adds error to give player chance :)
        positionError = new Vector3( Random.Range(-0.5f, 0.5f),  Random.Range(-0.5f, 0.5f)  );

        // Handles the weapon rotation
        followPlayer();

        timeBtwShots -= Time.deltaTime;
    }

}