using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _pauseTime;
    [SerializeField] private bool _isOrderRandom;
    [SerializeField] private int _quantityOfEnemies;

    private EnemySpawnPoint[] _spawnPoints;
    private Vector2 _spawnLocation;
    private Coroutine _spawnEnemiesJob;

    private void Awake()
    { 
        _spawnPoints = gameObject.GetComponentsInChildren<EnemySpawnPoint>();
    }

    private void Start()
    {
        _spawnEnemiesJob = StartCoroutine(SpawnEnemies(_pauseTime));
    }

    private IEnumerator SpawnEnemies(float pauseTime)
    {
        int enemyCounter = 0;
        int spawnPointIndex;

        if (!_isOrderRandom)
        {
            spawnPointIndex = 0;

            while (enemyCounter < _quantityOfEnemies)
            {
                _spawnLocation = new Vector2(_spawnPoints[spawnPointIndex].transform.position.x, _spawnPoints[spawnPointIndex].transform.position.y);
                Enemy newEnemy = Instantiate(_spawnPoints[spawnPointIndex].GetEnemy(), _spawnLocation, Quaternion.identity, _spawnPoints[spawnPointIndex].transform);

                newEnemy.SetMovementSpeed(_spawnPoints[spawnPointIndex].GetEnemyMovementSpeed());
                enemyCounter++;
                spawnPointIndex++;

                if (spawnPointIndex >= _spawnPoints.Length)
                {
                    spawnPointIndex = 0;
                }

                yield return new WaitForSeconds(pauseTime);
            }
        }
        else
        {
            while (enemyCounter < _quantityOfEnemies)
            {
                spawnPointIndex = Random.Range(0, _spawnPoints.Length);

                _spawnLocation = new Vector2(_spawnPoints[spawnPointIndex].transform.position.x, _spawnPoints[spawnPointIndex].transform.position.y);
                Enemy newEnemy = Instantiate(_spawnPoints[spawnPointIndex].GetEnemy(), _spawnLocation, Quaternion.identity, _spawnPoints[spawnPointIndex].transform);

                newEnemy.SetMovementSpeed(_spawnPoints[spawnPointIndex].GetEnemyMovementSpeed());
                enemyCounter++;

                yield return new WaitForSeconds(pauseTime);
            }
        }
    }
}
