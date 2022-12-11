using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _durationMultiplicator = 0.25f;
    private bool _isEnemyDetected;
    private uint _enemyNumber;
    private float minVolume = 0f;
    private float maxVolume = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsThisCollisionWithEnemy(collision))
        {
            _isEnemyDetected = true;
            _enemyNumber++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsThisCollisionWithEnemy(collision))
        {
            _enemyNumber--;

            if (_enemyNumber == 0)
            {
                _isEnemyDetected = false;
            }
        }
    }

    private void Update()
    {
        if (_isEnemyDetected == true && _audioSource.volume < maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxVolume, _durationMultiplicator * Time.deltaTime);
        }
        else if (_isEnemyDetected == false && _audioSource.volume > minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, minVolume, _durationMultiplicator * Time.deltaTime);
        }
    }

    private bool IsThisCollisionWithEnemy(Collider2D collision)
    {
        bool isEnemyDetected = false;

        if (collision.TryGetComponent<Authorisation>(out Authorisation authorisation))
        {
            if (authorisation.AccessDenied == true)
            {
                isEnemyDetected = true;
            }
        }

        return isEnemyDetected;
    }
}
