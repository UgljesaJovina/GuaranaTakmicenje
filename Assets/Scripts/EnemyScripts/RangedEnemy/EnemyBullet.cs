using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (collision.CompareTag("Enemy")) return;
        if (collision.isTrigger) return;

        if (collision.TryGetComponent(out IFriendlyDamagable damagable))
            damagable.TakeDamage(damage);

        Destroy(gameObject);
    }
}
