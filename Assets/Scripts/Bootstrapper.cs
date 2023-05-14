using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private PlayerHealth _playerHealth;
    private void Awake()
    {
        _gameStateManager.Init();
        _playerHealth.OnDie += _gameStateManager.SetLose;
    }
}
