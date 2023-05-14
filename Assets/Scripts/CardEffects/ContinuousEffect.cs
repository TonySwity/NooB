using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousEffect : Effect
{
    [SerializeField] private float _collDown;
    
    private float _timer;

    public void ProcessFrame(float frame)
    {
        _timer += frame;

        if (_timer > _collDown)
        {
            Produce();
            _timer = 0;
        }
    }

    protected virtual void Produce()
    {
        
    }
}
