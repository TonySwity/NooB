using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public string Name;
    [TextArea(1, 3)] public string Description;
    public Sprite Sprite;
    public int Level = -1;

    protected EffectsManager EffectsManager;
    protected Player Player;
    protected EnemyManager EnemyManager;

    public virtual void Initialize(EffectsManager effectsManager, EnemyManager enemyManager, Player player)
    {
        this.EffectsManager = effectsManager;
        this.EnemyManager = enemyManager;
        this.Player = player;
    }
    
    public virtual void Activate()
    {
        Level++;
    }
}
