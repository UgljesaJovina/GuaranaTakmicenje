using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public static Gun instance;

    [Header("Prefab setting")]
    [SerializeField] Transform firePoint;
    [SerializeField] Bullet bulletPrefab;

    [Header("Attack speed")]
    [SerializeField] float bulletsPerSecond = 5f;
    public float asMultiplier = 0f;
    [SerializeField] int clipSize;
    [SerializeField] float reloadTime = 0.5f;
    int currentBullets;
    bool reloading = false;
    float timeToShoot = 0f;
    [SerializeField] Text bulletsLeft;
    [SerializeField] Animator animator;

    [Header("Bullet damage")]
    [SerializeField] float baseBulletDamage = 10f;
    public float dmgMultiplier = 0f;

    private void Awake()
    {
        instance = this;
    }

    private void OnDrawGizmos()
    {
        if (Selection.activeGameObject == gameObject) Gizmos.DrawWireSphere(transform.position, 8);
    }

    private void Start()
    {
        currentBullets = clipSize;
    }

    void Update()
    {
        timeToShoot -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timeToShoot <= 0 && currentBullets > 0) Shoot();

        if (currentBullets <= 0 && !reloading) Reload();

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
        reloading = true;
        animator.Play("GunReload");
        await Task.Delay((int)(reloadTime * 1000));
        currentBullets = clipSize;
        reloading = false;
    }
}
