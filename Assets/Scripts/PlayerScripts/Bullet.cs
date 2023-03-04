using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 40f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float maxBulletRange = 20f;
    [HideInInspector] public float damage;
    Vector2 instantiationVector;

    void Start()
    {
        rb.velocity = bulletSpeed * transform.right;
        instantiationVector = transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, instantiationVector) > maxBulletRange) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        if (collision.isTrigger) return;

        if (collision.TryGetComponent(out IDamagable damagable)) 
            damagable.TakeDamage(damage);

        Destroy(gameObject);
    }
}
