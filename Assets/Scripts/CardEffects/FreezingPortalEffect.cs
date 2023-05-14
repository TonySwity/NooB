using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(FreezingPortalEffect), menuName = "Effects/ContinuousEffect/" + nameof(FreezingPortalEffect))]
public class FreezingPortalEffect : ContinuousEffect
{
    [SerializeField] private FreezingPortal _freezingPortalPref;
    [SerializeField] private float _damageFreezingPortal = 5f;
    [SerializeField] private float _timeReloadEffect = 15f;
    [SerializeField] private float _effectTime = 10f;
    [SerializeField] private float _enemySpeed = 2f;

    protected override void Produce()
    {
        base.Produce();
        EffectsManager.StartCoroutine(Effectprocess());
    }

    private IEnumerator Effectprocess()
    {
        FreezingPortal newFreezingPortal = Instantiate(_freezingPortalPref, Player.transform.position, Quaternion.identity);
        newFreezingPortal.Init(_damageFreezingPortal, _enemySpeed, _effectTime,_timeReloadEffect);
        Destroy(newFreezingPortal.gameObject, _effectTime);
        yield return null;
                
    }
}
