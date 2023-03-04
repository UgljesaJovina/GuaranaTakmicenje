using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent enemy;
    private Vector3 target;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy.updateRotation = false;
        enemy.updateUpAxis = false;
    }

    void Update()
    {
        SetTargetPosition();
        SetEnemyPosition();
    }
    void SetTargetPosition()
    {
        target = player.position;
    }
    void SetEnemyPosition()
    {
        enemy.SetDestination(target);
    }
}
