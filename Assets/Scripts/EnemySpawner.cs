using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _pauseTime;

    private SpawnPoint[] _spawnPoints;
    private Vector2 _spawnLocation;
    private Coroutine _spawnEnemiesJob;

    private void Awake()
    { 
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
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
            Enemy newEnemy = Instantiate(_enemy, _spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds(pauseTime);
        }
    }
}
