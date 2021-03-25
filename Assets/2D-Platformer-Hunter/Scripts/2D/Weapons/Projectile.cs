using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public List<string> TargetsTags;

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

    // called from RangedWeapon.cs
    public void Move(Vector3 direction) {
        rb.velocity = direction * speed;
    }

    private void Update()
    {
        SetAngle();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if( TargetsTags.Contains(collision.collider.gameObject.tag) ){   
            Debug.Log("hitted a target");
            collision.collider.GetComponent<IDamagable>().TakeDamage(damage);
        }
        DestroyProjectile();
    }

    void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
