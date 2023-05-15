using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreasureSpawner : MonoBehaviour
{
    [SerializeField] private Treasure _treasure;

    private TreasureSpawnPoint[] _spawnPoints;
    private Vector2 _spawnLocation;
    private Coroutine _spawnTreasureJob;

    private void Awake()
    { 
        _spawnPoints = gameObject.GetComponentsInChildren<TreasureSpawnPoint>();
    }

    private void Start()
    {
        _spawnTreasureJob = StartCoroutine(SpawnTreasure());
    }

    private IEnumerator SpawnTreasure()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnLocation = new Vector2(_spawnPoints[i].transform.position.x, _spawnPoints[i].transform.position.y);
            Treasure newTreasure = Instantiate(_treasure, _spawnLocation, Quaternion.identity);

            yield return null;
        }
    }
}
