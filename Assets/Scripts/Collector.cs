using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RemoteNotification = UnityEngine.iOS.RemoteNotification;

public class Collector : MonoBehaviour
{
    [SerializeField] private float _distanceToCollect = 2f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ExperienceManager _experienceManager;
    [SerializeField] private ParticleSystem _levelUpEffectPref;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distanceToCollect, _layerMask, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<Loot>() is Loot loot)
            {
                loot.Collect(this);
            }
        }
    }

    public void TakeExperience(int value)
    {
        _experienceManager.AddExperience(value);
    }
    
    public void LevelUpEffect()
    {
        ParticleSystem lvlUp = Instantiate(_levelUpEffectPref, transform.position, Quaternion.identity);

        StartCoroutine(MoveToCollector(lvlUp.gameObject));
        
        Destroy(lvlUp, 3f);
        

    }
    
    private IEnumerator MoveToCollector(GameObject obj)
    {
        for (float t = 0; t < 3f; t += Time.deltaTime)
        {
            Vector3 position = transform.position;
            obj.transform.position = position;
            yield return null;
        }
    }
    
    
}
