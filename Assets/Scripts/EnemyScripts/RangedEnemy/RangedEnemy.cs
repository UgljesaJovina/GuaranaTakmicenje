using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangedEnemy : Enemy
{
    bool isChasing = false;
    Transform currentTarget;
    [SerializeField] LayerMask whatIsPlayer;

    [SerializeField] float weaponRange = 10f;
    float timeBetweenAttacks = 0f;

    [SerializeField] SpriteRenderer body, weaponRenderer;

    [SerializeField] Transform weaponHilt, firePoint;
    [SerializeField] EnemyBullet bullet;

    Vector3 enemyTargetVector;

    private void OnDrawGizmos()
    {
        if (Selection.activeGameObject == gameObject) Gizmos.DrawWireSphere(transform.position, weaponRange);
    }

    void Start()
    {
        currentTarget = grandOwl;
    }

    void Update()
    {
        timeBetweenAttacks -= Time.deltaTime;

        var player = Physics2D.OverlapCircle(transform.position, stats.detectionRadius, whatIsPlayer);
        if (player)
        {
            isChasing = true;
            currentTarget = player.transform;
        }

        agent.SetDestination(currentTarget.position);
        agent.speed = isChasing ? stats.movementSpeed : stats.movementSpeed - (stats.movementSpeed * stats.idleSlowMult);

        if (Vector2.Distance(transform.position, currentTarget.position) <= weaponRange && timeBetweenAttacks <= 0)
            Attack();

    }

    private void LateUpdate()
    {
        enemyTargetVector = currentTarget.position - transform.position;
        enemyTargetVector.Normalize();

        float zRot = Mathf.Atan2(enemyTargetVector.y, enemyTargetVector.x) * Mathf.Rad2Deg;

        weaponHilt.rotation = Quaternion.Euler(0, 0, zRot);

        if (zRot > 90 || -90f >= zRot)
        {
            body.flipX = true;
            weaponRenderer.flipY = true;
        }
        else
        {
            body.flipX = false;
            weaponRenderer.flipY = false;
        }
    }

    void Attack()
    {
        EnemyBullet eb1 = Instantiate(bullet, firePoint.position + firePoint.up * .1f, firePoint.rotation);
        EnemyBullet eb2 = Instantiate(bullet, firePoint.position - firePoint.up * .1f, firePoint.rotation);

        eb1.damage = stats.damage;
        eb2.damage = stats.damage;

        timeBetweenAttacks = stats.attackSpeed;
    }
}
