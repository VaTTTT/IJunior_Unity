using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _pauseTime;

    private SpawnPoint[] _spawnPoints;
    private Vector2 _spawnLocation;
    private Coroutine _spawnEnemiesJob;
    private float _passedTime;

    private void Awake()
    { 
        _spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        _spawnEnemiesJob = StartCoroutine(SpawnEnemies(_spawnTime, _pauseTime));
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;
    }

    private IEnumerator SpawnEnemies(float spawnTime, float pauseTime)
    {
        int spawnPointNumber;

        _passedTime = 0;
        
        while (_passedTime < spawnTime) 
        {
            spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            _spawnLocation = new Vector2(_spawnPoints[spawnPointNumber].transform.position.x, _spawnPoints[spawnPointNumber].transform.position.y);
            GameObject newEnemy = Instantiate(_enemy, _spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds(pauseTime);
        }
    }
}
