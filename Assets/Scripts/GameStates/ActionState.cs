using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : GameState
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private RigidbodyMove _rigidbodyMove;

    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private ExperienceManager _experienceManager;

    public override void EnterFirstState()
    {
        base.EnterFirstState();
        _enemyManager.StartNewWave(0);
        _experienceManager.UpLevel();
    }
    

    public override void Enter()
    {
        base.Enter();
        _joystick.Activate();
        _rigidbodyMove.enabled = true;
    }

    public override void Exit()
    {
        base.Exit();
        _joystick.Deactivate();
        _rigidbodyMove.enabled = false;
    }
}
