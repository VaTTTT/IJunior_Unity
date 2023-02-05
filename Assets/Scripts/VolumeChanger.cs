using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _minimalVolume;
    [SerializeField] private float _maximalVolume;
    [SerializeField] private float _timeOfChanging;

    private Coroutine _decreaseVolumeJob;
    private Coroutine _increaseVolumeJob;
    private float _startingVolume;
    private float _passedTime;

    private void Awake()
    {
        _audioSource.volume = 0;    
    }

    public void LinearDecreasing()
    {      
        _decreaseVolumeJob = StartCoroutine(DecreaseVolume());
    }

    public void LinearIncreasing()
    {
        _increaseVolumeJob = StartCoroutine(IncreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        _passedTime = 0;
        _startingVolume = _audioSource.volume;

        if (_decreaseVolumeJob != null)
        {
            StopCoroutine(_decreaseVolumeJob);
        }

        while (_passedTime < _timeOfChanging)
        {
            _passedTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_startingVolume, _maximalVolume, _passedTime / _timeOfChanging);
                       
            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        _passedTime = 0;
        _startingVolume = _audioSource.volume;

        if (_increaseVolumeJob != null)
        {
            StopCoroutine(_increaseVolumeJob);
        }

        while (_passedTime < _timeOfChanging)
        {
            _passedTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_startingVolume, _minimalVolume, _passedTime / _timeOfChanging);

            yield return null;
        }
    }
}
