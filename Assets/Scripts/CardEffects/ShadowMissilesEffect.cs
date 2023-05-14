using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = nameof(ShadowMissilesEffect), menuName = "Effects/ContinuousEffect/" + nameof(ShadowMissilesEffect))]
public class ShadowMissilesEffect : ContinuousEffect
{
    [SerializeField] private ShadowMissile _shadowMissilePref;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damageBullet = 20f;
    [SerializeField] private int _passCountBullet = 2;
    
    protected override void Produce()
    {
        base.Produce();

        Transform playerTransform = Player.transform;
        int number = 5;


        for (int i = 0; i < number; i++)
        {
            float angle = (360f / 5) * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * playerTransform.forward;
            ShadowMissile newBullet = Instantiate(_shadowMissilePref, playerTransform.position, Quaternion.identity);
            newBullet.Setup(direction * _bulletSpeed, _damageBullet, _passCountBullet);
        }
    }
}
