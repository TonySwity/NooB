using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _rotationLerpRate = 5f;
    
    [SerializeField] private float _distanceToPlayer = 32f;
    [SerializeField] private float _offsetToPlayerDistance = 1.9f;

    private float _attackTimer;
    [SerializeField] private float _attackPeriod = 1f;
    [SerializeField] private float _dps = 5f;

    private PlayerHealth _playerHealth;
    [SerializeField] private float _health = 50f;
    [SerializeField] private GameObject _dieEffect;

    private EnemyManager _enemyManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_playerHealth)
        {
            _attackTimer += Time.deltaTime;

            if (_attackTimer > _attackPeriod)
            {
                _playerHealth.TakeDamage(_dps * _attackPeriod);
                _attackTimer = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_playerTransform)
        {
            Vector3 toPlayer = _playerTransform.position - transform.position;
            Quaternion toPlayerRotation = Quaternion.LookRotation(toPlayer, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toPlayerRotation, Time.deltaTime * _rotationLerpRate);
            _rigidbody.velocity = transform.forward * _speed;

            if (toPlayer.magnitude > _distanceToPlayer)
            {
                transform.position += toPlayer * _offsetToPlayerDistance;
            }
        }
    }


    public void Init(Transform playerTransform, EnemyManager enemyManager)
    {
        _playerTransform = playerTransform;
        _enemyManager = enemyManager;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            Debug.Log("PLAYER");
            
            _playerHealth = playerHealth;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            _playerHealth = null;
        }
    }
    public void SetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(_dieEffect, transform.position, Quaternion.identity);
        _enemyManager.Remove(this);
        Destroy(gameObject);
    }
}
