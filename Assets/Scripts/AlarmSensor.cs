using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyDetected;
    [SerializeField] private UnityEvent _enemyLeftProtectedZone;

    private int _enemyNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsThisCollisionWithEnemy(collision))
        {
            _enemyNumber++;
            _enemyDetected.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsThisCollisionWithEnemy(collision))
        {
            _enemyNumber--;

            if (_enemyNumber == 0)
            {
                _enemyLeftProtectedZone.Invoke();
            }
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
