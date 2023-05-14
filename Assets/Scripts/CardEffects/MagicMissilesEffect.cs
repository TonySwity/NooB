using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(MagicMissilesEffect), menuName = "Effects/ContinuousEffect/" + nameof(MagicMissilesEffect))]
public class MagicMissilesEffect : ContinuousEffect
{
    [SerializeField] private MagicMissile _magicMissilePref;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damageMagicMissile = 20f;
    [SerializeField] private int _countBullet = 4;

    protected override void Produce()
    {
        base.Produce();
        EffectsManager.StartCoroutine(Effectprocess());
    }

    private IEnumerator Effectprocess()
    {
        int number = _countBullet;
        Enemy[] nearestEnemies = EnemyManager.GetNearest(Player.transform.position, number);

        if (nearestEnemies.Length > 0)
        {
            for (int i = 0; i < nearestEnemies.Length; i++)
            {
                Vector3 position = Player.transform.position;
                MagicMissile newMagicMissile = Instantiate(_magicMissilePref, position, Quaternion.identity);
                newMagicMissile.Init(nearestEnemies[i], _damageMagicMissile, _bulletSpeed);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
