using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
        // camAnim.SetTrigger("shake");
        Invoke("DestroyProjectile", lifeTime);
    }

    void SetAngle(){
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // called from Weapon.cs
    public void Move(Vector3 direction) {
        rb.velocity = direction * speed;
    }

    private void Update()
    {
        SetAngle();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy")) {
            Debug.Log("something in enemy");
            collision.collider.GetComponent<IDamagable>().TakeDamage(damage);
            DestroyProjectile();
        }
        // Layer : 9 => Environment
        else if( collision.collider.gameObject.layer == 9 ){    
            DestroyProjectile();
        }
    }

    void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
