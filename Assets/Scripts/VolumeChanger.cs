using System.Collections;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _minimalVolume;
    [SerializeField] private float _maximalVolume;
    [SerializeField] private float _timeOfChanging;

    private Coroutine _changeVolumeJob;
    private float _startingVolume;
    private float _passedTime;

    private void Awake()
    {
        _audioSource.volume = 0;    
    }

    public void LinearDecreasing()
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        _changeVolumeJob = StartCoroutine(ChangeVolume(_minimalVolume));
    }

    public void LinearIncreasing()
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }
        
        _changeVolumeJob = StartCoroutine(ChangeVolume(_maximalVolume));
    }   

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _passedTime = 0;
        _startingVolume = _audioSource.volume;

        while (_passedTime < _timeOfChanging)
        {
            _passedTime += Time.deltaTime;
            _audioSource.volume = Mathf.MoveTowards(_startingVolume, targetVolume, _passedTime / _timeOfChanging);

            yield return null;
        }
    }
}
