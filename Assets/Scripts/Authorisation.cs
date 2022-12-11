using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authorisation : MonoBehaviour
{
    [SerializeField] private bool _accessDenied;

    public bool AccessDenied => _accessDenied;
}
