using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private float _experience = 0f;
    [SerializeField] private float _nextLevelExperience = 5;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _experienceScale;
    [SerializeField] private EffectsManager _effectsManager;
    [SerializeField] private AnimationCurve _experienceCurve;

    public UnityEvent OnLevelUp;

    private int _level = -1;
    private void Awake()
    {
        _nextLevelExperience = _experienceCurve.Evaluate(0);
    }

    private void Start()
    {
        UpdateLevelText();
    }

    public void AddExperience(int value)
    {
        _experience += value;

        if (_experience >= _nextLevelExperience)
        {
            UpLevel();
        }
        
        DisplayExperience();
    }

    public void UpLevel()
    {
        
        _level++;
        OnLevelUp.Invoke();
        StartCoroutine(WaitTimeShowCards());
        UpdateLevelText();
        _experience = 0;
        _nextLevelExperience = _experienceCurve.Evaluate(_level);
    }

    private void DisplayExperience()
    {
        _experienceScale.fillAmount = _experience / _nextLevelExperience;
    }

    private IEnumerator WaitTimeShowCards()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        _effectsManager.ShowCards();
    }

    private void UpdateLevelText()
    {
        _levelText.text = _level.ToString();
    }
}
