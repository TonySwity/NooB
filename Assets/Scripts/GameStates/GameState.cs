using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    protected GameStateManager GameStateManager;
    private bool _wasSet;

    public virtual void Init(GameStateManager gameStateManager)
    {
        this.GameStateManager = gameStateManager;
    }

    public virtual void EnterFirstState()
    {
        _wasSet = true;
    }
    
    public virtual void Enter()
    {
        if (!_wasSet)
        {
            EnterFirstState();
        }
    }

    public virtual void Exit()
    {
        
    }
}
