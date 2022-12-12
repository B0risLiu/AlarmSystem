using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Siren : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _workingCoroutine;
    private float _durationMultiplicator = 0.2f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void StartChangeVolume(float targetVolume)
    {
        if (_workingCoroutine != null)
            StopCoroutine(_workingCoroutine);
        _workingCoroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _durationMultiplicator * Time.deltaTime);
            yield return null;
        }
        _workingCoroutine = null;
    }

    public void SirenOn()
    {
        StartChangeVolume(_maxVolume);
    }

    public void SirenOff()
    {
        StartChangeVolume(_minVolume);
    }
}
