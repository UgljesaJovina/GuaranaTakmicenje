using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Prefab setting")]
    [SerializeField] Transform firePoint;
    [SerializeField] Bullet bulletPrefab;

    [Header("Attack speed")]
    [SerializeField] float bulletsPerSecond = 5f;
    public float asMultiplier = 0f;
    [SerializeField] int clipSize;
    [SerializeField] float reloadTime = 0.5f;
    int currentBullets;
    float timeToShoot = 0f;
    [SerializeField] Text bulletsLeft;

    [Header("Bullet damage")]
    [SerializeField] float baseBulletDamage = 10f;
    public float dmgMultiplier = 0f;

    private void Start()
    {
        currentBullets = clipSize;
    }

    void Update()
    {
        timeToShoot -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timeToShoot <= 0 && currentBullets > 0) Shoot();

        if (currentBullets <= 0) Reload();

        bulletsLeft.text = $"Bullets: {currentBullets}";
    }

    void Shoot()
    {
        currentBullets--;

        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.damage = baseBulletDamage + baseBulletDamage * dmgMultiplier;

        timeToShoot = 1 / (bulletsPerSecond + bulletsPerSecond * asMultiplier);
    }

    async void Reload()
    {
        await Task.Delay((int)(reloadTime * 1000));
        currentBullets = clipSize;
    }
}
