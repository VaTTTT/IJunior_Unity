using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _pauseTime;

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
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnLocation = new Vector2(_spawnPoints[i].transform.position.x, _spawnPoints[i].transform.position.y);
            Enemy newEnemy = Instantiate(_spawnPoints[i].GetEnemy(), _spawnLocation, Quaternion.identity, _spawnPoints[i].transform);
            newEnemy.SetMovementSpeed(_spawnPoints[i].GetEnemyMovementSpeed());

            yield return new WaitForSeconds(pauseTime);
        }
    }
}
