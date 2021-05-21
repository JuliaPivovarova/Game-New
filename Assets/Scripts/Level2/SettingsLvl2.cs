using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsLvl2 : MonoBehaviour
{
    [SerializeField]
    private Button _btnDiftyEasy;

    [SerializeField]
    private Button _btnDiftyNormal;

    [SerializeField]
    private Button _btnBack;

    [SerializeField]
    private GameObject _gargFirst;

    [SerializeField]
    private GameObject _settings;

    private void Awake()
    {
        _btnDiftyNormal.interactable = false;
        _btnDiftyEasy.interactable = true;
    }

    private void Start()
    {
        _btnDiftyEasy.onClick.AddListener(DiffOnEasy);
        _btnDiftyNormal.onClick.AddListener(DiffOnNormal);
        _btnBack.onClick.AddListener(Back);
    }

    private void OnDestroy()
    {
        _btnDiftyEasy.onClick.RemoveAllListeners();
        _btnDiftyNormal.onClick.RemoveAllListeners();
        _btnBack.onClick.RemoveAllListeners();
    }

    private void DiffOnEasy()
    {
        _btnDiftyNormal.interactable = true;
        _gargFirst.SetActive(false);
        _btnDiftyEasy.interactable = false;
    }

    private void DiffOnNormal()
    {
        _btnDiftyEasy.interactable = true;
        _gargFirst.SetActive(true);
        _btnDiftyNormal.interactable = false;
    }

    private void Back()
    {
        _settings.SetActive(false);
    }
}
