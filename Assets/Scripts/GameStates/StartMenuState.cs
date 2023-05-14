using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuState : GameState
{
    [SerializeField] private Button _tapToStartButton;
    [SerializeField] private GameObject _startMenuGameObject;

    public override void Init(GameStateManager gameStateManager)
    {
        base.Init(gameStateManager);
        _tapToStartButton.onClick.AddListener(gameStateManager.SetAction);
    }

    public override void Enter()
    {
        base.Enter();
        _startMenuGameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        _startMenuGameObject.SetActive(false);
    }
}
