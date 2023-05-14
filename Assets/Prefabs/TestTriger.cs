using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriger : MonoBehaviour
{
    private float _damage;
    private void Start()
    {
        _damage = 20f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.SetDamage(_damage);
        }
    }
}
