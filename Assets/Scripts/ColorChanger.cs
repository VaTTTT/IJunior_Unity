using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer Target;

    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColour;

    private float _runningTime;
    private Color _startColor;

    private void Start()
    {
        Target = GetComponent<SpriteRenderer>();
        _startColor = Target.color;
    }

    private void Update()
    {
        if (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;
            float normalizeRunningTime = _runningTime / _duration;
            Target.color = Color.Lerp(_startColor, _targetColour, normalizeRunningTime);
            
            Debug.Log("Color - " + Target.color);
        }
    }
}
