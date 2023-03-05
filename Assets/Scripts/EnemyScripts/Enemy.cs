using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    public event DeathDelegate deathEvent;

    public EnemyStats stats;

    public Transform grandOwl;

    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected Animator animator;

    public int enemyScore = 0;
    public int enemyMoney = 0;

    void Awake()
    {
        deathEvent += Death;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void OnDrawGizmos()
    {
        if (Selection.activeGameObject != gameObject)
            return;

        Gizmos.DrawWireSphere(transform.position, stats.detectionRadius);
    }

    public void TakeDamage(float damage)
    {
        stats.health -= damage;
        if (stats.health <= 0)
            deathEvent(this);
    }

    public void Death(Enemy sender)
    {
        Destroy(gameObject);
    }

    public delegate void DeathDelegate(Enemy sender);
}
