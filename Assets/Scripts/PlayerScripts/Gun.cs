using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Prefab setting")]
    [SerializeField] Transform firePoint;
    [SerializeField] Bullet bulletPrefab;

    [Header("Attack speed")]
    [SerializeField] float bulletsPerSecond = 5f;
    public float asMultiplier = 0f;
    float timeToShoot = 0f;

    [Header("Bullet damage")]
    [SerializeField] float baseBulletDamage = 10f;
    public float dmgMultiplier = 0f;

    void Update()
    {
        timeToShoot -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timeToShoot <= 0) Shoot();
    }

    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.damage = baseBulletDamage + baseBulletDamage * dmgMultiplier;

        timeToShoot = 1 / (bulletsPerSecond + bulletsPerSecond * asMultiplier);
    }
}
