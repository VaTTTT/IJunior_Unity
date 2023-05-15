using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _enemyMovementSpeed;
    [SerializeField] private Transform[] _enemyWayPoints;

    public Enemy GetEnemy() 
    { 
        return _enemy; 
    }

    public float GetEnemyMovementSpeed()
    { 
        return _enemyMovementSpeed;
    }

    public Transform GetEnemyWayPoint(int waypointNumber) 
    { 
        return _enemyWayPoints[waypointNumber];
    }

    public int GetEnemyWayPointQuantity()
    { 
        return _enemyWayPoints.Length;
    }
}
