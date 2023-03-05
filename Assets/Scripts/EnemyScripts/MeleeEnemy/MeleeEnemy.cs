using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    bool isChasing = false;
    Transform currentTarget;
    [SerializeField] LayerMask whatIsPlayer;

    [SerializeField] float weaponRange = 1f;
    [SerializeField] float timeBetweenAttacks = 0f;
    [SerializeField] float attackTime = .35f;

    [SerializeField] Animator weaponAnimator, clawAnimator;
    [SerializeField] Transform weaponHilt;

    [SerializeField] Transform pivotsPivot, pivot, particlePivot;
    [SerializeField] SpriteRenderer body;

    [SerializeField] Sword sword;
    [SerializeField] Collider2D swordCollider;

    Vector3 enemyTargetVector;
    bool attacking = false;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(weaponHilt.position, weaponRange);
    }

    void Start()
    {
        currentTarget = grandOwl;
        sword.damage = stats.damage;
    }

    void Update()
    {
        var player = Physics2D.OverlapCircle(transform.position, stats.detectionRadius, whatIsPlayer);
        if (player)
        {
            isChasing = true;
            currentTarget = player.transform;
        }

        agent.SetDestination(currentTarget.position);
        agent.speed = isChasing ? stats.movementSpeed : stats.movementSpeed - (stats.movementSpeed * stats.idleSlowMult);

        if (attacking) { agent.velocity = Vector3.zero; agent.isStopped = true; } 
        else agent.isStopped = false;

        swordCollider.enabled = attacking;

        //animator.SetBool("Running", agent.velocity != Vector3.zero);
        
        if (Vector2.Distance(transform.position, currentTarget.position) <= weaponRange && timeBetweenAttacks <= 0)
            Attack();

        timeBetweenAttacks -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        enemyTargetVector = currentTarget.position - transform.position;
        enemyTargetVector.Normalize();

        float zRot = Mathf.Atan2(enemyTargetVector.y, enemyTargetVector.x) * Mathf.Rad2Deg;

        if (!attacking) weaponHilt.rotation = Quaternion.Euler(0, 0, zRot);

        if (zRot > 90 || -90f >= zRot)
        {
            body.flipX = true;
            pivotsPivot.localPosition = new Vector3(-0.5f, 0, 0);
            pivot.localScale = new Vector3(-1, 1, 1);
            particlePivot.localPosition = new Vector3(1.1f, .4f, 0);
            particlePivot.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            body.flipX = false;
            pivotsPivot.localPosition = Vector3.zero;
            pivot.localScale = new Vector3(1, 1, 1);
            particlePivot.localPosition = new Vector3(0, 0, 0);
            particlePivot.localScale = new Vector3(1, 1, 1);
        }
    }

    async void Attack()
    {
        attacking = true;
        weaponAnimator.SetTrigger("Attack");
        clawAnimator.SetTrigger("Attack");
        timeBetweenAttacks = stats.attackSpeed;
        await Task.Delay((int)(attackTime * 750));
        swordCollider.enabled = true;
        weaponAnimator.ResetTrigger("Attack");
        clawAnimator.ResetTrigger("Attack");
        await Task.Delay((int)(attackTime * 250));
        timeBetweenAttacks = stats.attackSpeed;
        attacking = false;
        swordCollider.enabled = false;
    }
}
