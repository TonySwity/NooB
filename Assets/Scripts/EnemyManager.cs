using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _creationRadius;
    [SerializeField] private ChapterSettings _chapterSettings;
    private List<Enemy> _enemyLists = new List<Enemy>();

    public void StartNewWave(int wave)
    {
        StopAllCoroutines();
        
        for (int i = 0; i < _chapterSettings.EnemyWavesArray.Length; i++)
        {
            if (_chapterSettings.EnemyWavesArray[i].NumberPerSeconds[wave ] > 0)
            {
                StartCoroutine(CreateEnemyInSeconds(_chapterSettings.EnemyWavesArray[i].Enemy, _chapterSettings.EnemyWavesArray[i].NumberPerSeconds[wave]));
            }
        }
    }

    public void Create(Enemy enemy)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 position = new Vector3(randomPoint.x, 0, randomPoint.y) * _creationRadius + _playerTransform.position;
        
        Enemy newEnemy =  Instantiate(enemy,position, Quaternion.identity);
        newEnemy.Init(_playerTransform, this);
        _enemyLists.Add(newEnemy);
    }

    public void Remove(Enemy enemy)
    {
        _enemyLists.Remove(enemy);
    }

    private IEnumerator CreateEnemyInSeconds(Enemy enemy, float enemyPerSeconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / enemyPerSeconds);
            Create(enemy);
        }
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.color = Color.red;
        Handles.DrawWireDisc(_playerTransform.position, Vector3.up, _creationRadius);
#endif
    }
    public Enemy[] GetNearest(Vector3 point, int number)
    {
        _enemyLists = _enemyLists.OrderBy(x => Vector3.Distance(point, x.transform.position)).ToList();
        int returnNumber = Mathf.Min(number, _enemyLists.Count);
        Enemy[] enemies = new Enemy[returnNumber];

        for (int i = 0; i < returnNumber; i++)
        {
            enemies[i] = _enemyLists[i];
        }

        return enemies;
    }
}
