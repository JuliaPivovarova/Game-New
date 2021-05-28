using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Button _btnDiftyEasy;

    [SerializeField]
    private Button _btnDiftyNormal;

    [SerializeField]
    private Button _btnBack;

    [SerializeField]
    private GameObject _ghostFirst;

    [SerializeField]
    private GameObject _ghostSecond;

    [SerializeField]
    private GameObject _hound;

    [SerializeField]
    private GameObject _settings;

    [SerializeField]
    private Light _shadows;

    [SerializeField]
    private Slider _shadowSlider;

    private bool _diffNormal;

    private void Awake()
    {
        _btnDiftyNormal.interactable = false;
        _btnDiftyEasy.interactable = true;
        _diffNormal = false;
    }

    private void Start()
    {
        _btnDiftyEasy.onClick.AddListener(Diff);
        _btnDiftyNormal.onClick.AddListener(Diff);
        _btnBack.onClick.AddListener(Back);
        _shadowSlider.onValueChanged.AddListener(Shadows);
    }

    private void OnDestroy()
    {
        _btnDiftyEasy.onClick.RemoveAllListeners();
        _btnDiftyNormal.onClick.RemoveAllListeners();
        _btnBack.onClick.RemoveAllListeners();
        _shadowSlider.onValueChanged.RemoveAllListeners();
    }

    private void Diff()
    {
        if (_diffNormal)
        {
            _btnDiftyEasy.interactable = true;
            _ghostFirst.SetActive(true);
            _ghostSecond.SetActive(true);
            _hound.SetActive(true);
            _btnDiftyNormal.interactable = false;
        }
        else
        {
            _btnDiftyNormal.interactable = true;
            _ghostFirst.SetActive(false);
            _ghostSecond.SetActive(false);
            _hound.SetActive(false);
            _btnDiftyEasy.interactable = false;
        }       
    }

    private void Back()
    {
        _settings.SetActive(false);
    }

    private void Shadows(float value)
    {
        _shadows.shadowStrength = _shadowSlider.value;
    }
}
