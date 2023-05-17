using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingPortal : MonoBehaviour
{
    [SerializeField]private float _damage;
    private float _timeReloadEffect;//*
    private float _effectTime;
    private float _enemySpeed;
    // немного запутался во всем поэтому один эффект и с не очень реализацией=(
    private Enemy _enemy;
    private Coroutine _enemyDamageCoroutine;
    [SerializeField]private float _timer;
    
    public void Init(float damage, float enemySpeed, float effectTime, float reloadTime)
    {
        _damage = damage;
        _enemySpeed = enemySpeed;
        _effectTime = effectTime;
        _timeReloadEffect = reloadTime;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            _enemy = enemy;
            _enemyDamageCoroutine = StartCoroutine(EnemyDamage());
            
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        _timer += Time.deltaTime;
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            _enemy = enemy;

            if (_timer >= 2f)
            {
                _timer = 0;
                _enemy.SetSpeed(_enemySpeed, _effectTime);
                _enemyDamageCoroutine = StartCoroutine(EnemyDamage());
                
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            StopCoroutine(_enemyDamageCoroutine);
            _enemy = null;
        }
    }

    private IEnumerator EnemyDamage()
    {
        yield return new WaitForSeconds(2f);
        _enemy.SetDamage(_damage);
    }
}
