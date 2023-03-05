using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats 
{
    public float damage;
    public float attackSpeed;
    public float health;
    public float movementSpeed;
    public float detectionRadius;
    public float idleSlowMult = 0.4f;

    public EnemyStats(EnemyStats stats)
    {
        damage = stats.damage;
        attackSpeed = stats.attackSpeed;
        health = stats.health;
        movementSpeed = stats.movementSpeed;
        detectionRadius = stats.detectionRadius;
        idleSlowMult = stats.idleSlowMult;
    }

    public void MultiplyStats(float multiplier)
    {
        damage += damage * multiplier;
        health += health * multiplier;
    }
}
