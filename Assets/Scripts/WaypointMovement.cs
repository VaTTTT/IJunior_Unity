using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    /*
    private int _currentPoint;

    private void Start()
    {
        if (GetComponentInParent<EnemySpawnPoint>().GetEnemyWayPointQuantity() == 0)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        Transform target = GetComponentInParent<EnemySpawnPoint>().GetEnemyWayPoint(_currentPoint);

        transform.position = Vector3.MoveTowards(transform.position, target.position, GetComponent<Enemy>().Speed * Time.deltaTime);
       
        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= GetComponentInParent<EnemySpawnPoint>().GetEnemyWayPointQuantity())
            {
                _currentPoint = 0;
            }
        }
    }
    */
}
