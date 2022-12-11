using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _body2d;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _body2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            if (inputX < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }

            _animator.SetBool("IsMoving", true);
            _body2d.velocity = new Vector2(inputX * _speed, _body2d.velocity.y);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
}
