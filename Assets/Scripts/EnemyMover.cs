using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private int _currentWayPointIndex;
    private int _wayPointsNumber;
    private Transform[] _wayPoints;
    private Transform _target;

    public void SetWayPoints(Transform[] points)
    {
        _wayPoints = points;
    }

    private void Start()
    {
        _wayPointsNumber = _wayPoints.Length;
        _currentWayPointIndex = 0;
    }

    private void Update()
    {
        if (_wayPointsNumber != 0)
        {
            _target = _wayPoints[_currentWayPointIndex];

            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

            if (transform.position == _target.position)
            {
                _currentWayPointIndex++;

                if (_currentWayPointIndex >= _wayPointsNumber)
                {
                    _currentWayPointIndex = 0;
                }
            }
        }
    }
}