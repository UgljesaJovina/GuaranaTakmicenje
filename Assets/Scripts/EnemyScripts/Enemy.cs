using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    public event DeathDelegate deathEvent;

    public EnemyStats stats;

    public Transform grandOwl, player;

    public int enemyScore = 0;
    public int enemyMoney = 0;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, stats.detectionRadius);
    }

    protected void CallDeathEvent()
    {
        deathEvent(this);
    }

    public void TakeDamage(float damage)
    {
        stats.damage -= damage;
    }

    public delegate void DeathDelegate(Enemy sender);
}
