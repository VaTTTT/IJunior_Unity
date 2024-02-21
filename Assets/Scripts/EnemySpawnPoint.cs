using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _enemyWayPoints;

    public void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        
        if (newEnemy.TryGetComponent<EnemyMover>(out EnemyMover mover))
        {
            mover.SetWayPoints(_enemyWayPoints);
        }
    }
}