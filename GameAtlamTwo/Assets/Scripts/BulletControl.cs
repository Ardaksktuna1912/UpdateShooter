using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _movement;

    public void Fire(Vector3 direction)
    {
        _movement = direction * _speed * Time.deltaTime;

    }
    private void FixedUpdate()
    {
        transform.position += _movement;
    }
}
