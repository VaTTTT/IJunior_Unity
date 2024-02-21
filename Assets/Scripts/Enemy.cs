using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;

    public void SetMovementSpeed(float speed)
    { 
        _speed = speed;
    }

    public float GetMovementSpeed()
    { 
        return _speed;
    }
}