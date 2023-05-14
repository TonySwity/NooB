using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

public class FreezingPortal : MonoBehaviour
{
    private float _damage;
    private float _timeReloadEffect;
    private float _effectTime;
    private float _enemySpeed;
    // немного запутался во всем поэтому один эффект и с не очень реализацией=(
    private Enemy _enemy;
    private Coroutine _enemyDamageCoroutine;
    public void Init(float damage, float enemySpeed, float effectTime, float reloadTime)
    {
        _damage = damage;
        _enemySpeed = enemySpeed;
        _effectTime = effectTime;
        _timeReloadEffect = reloadTime;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemy = enemy;
            Debug.Log("EnemyDamage");
            _enemyDamageCoroutine = StartCoroutine(EnemyDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            StopCoroutine(_enemyDamageCoroutine);
            Destroy(this, 3f);
            _enemy = null;
        }
    }

    private IEnumerator EnemyDamage()
    {
        _enemy.SetDamage(_damage);
        yield return new WaitForSeconds(1f);
    }
}
