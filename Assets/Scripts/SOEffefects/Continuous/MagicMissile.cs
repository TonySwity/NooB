using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    private Enemy _targetEnemy;
    private float _speed;
    private float _damage;
    [SerializeField] private float _lifeTime = 4f;

    public void Init(Enemy targetEnemy, float damage, float speed)
    {
        _targetEnemy = targetEnemy;
        _damage = damage;
        _speed = speed;
        
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        if (_targetEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetEnemy.transform.position, _speed * Time.deltaTime);
            
            if (transform.position == _targetEnemy.transform.position)
            {
                AffectEnemy();
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AffectEnemy()
    {
        _targetEnemy.SetDamage(_damage);
    }
}
