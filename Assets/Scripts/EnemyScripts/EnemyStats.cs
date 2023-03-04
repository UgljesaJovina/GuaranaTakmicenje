using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats 
{
    public float damage;
    public float health;
    public float movementSpeed;
    public float detectionRadius;

    public EnemyStats(EnemyStats stats)
    {
        damage = stats.damage;
        health = stats.health;
        movementSpeed = stats.movementSpeed;
        detectionRadius = stats.detectionRadius;
    }

    public void MultiplyStats(float multiplier)
    {
        damage += damage * multiplier;
        health += health * multiplier;
    }
}
