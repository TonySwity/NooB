using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _iconBackground;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _continuousEffectSprite;
    [SerializeField] private Sprite _oneTimeEffectSprite;

    private Effect _effect;

    private EffectsManager _effectsManager;
    private CardManager _cardManager;

    public void Init(EffectsManager effectsManager, CardManager cardManager)
    {
        this._effectsManager = effectsManager;
        this._cardManager = cardManager;
        this._button.onClick.AddListener(Click);
    }
    public void Show(Effect effect)
    {
        this._effect = effect;
        this._nameText.text = effect.Name;
        this._descriptionText.text = _effect.Description;
        this._levelText.text = effect.Level.ToString();
        this._iconImage.sprite = effect.Sprite; 

        if (effect is ContinuousEffect)
        {
            this._iconBackground.sprite = _continuousEffectSprite;
        }
        else if (effect is OneTimeEffect)
        {
            this._iconBackground.sprite = _oneTimeEffectSprite;
        }
    }

    public void Click()
    {
        _effectsManager.AddEffect(this._effect);
        _cardManager.Hide();
    }
}
