using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject _pause;
    
    [SerializeField]
    private Button _btnSettings;

    [SerializeField]
    private GameObject _settings;

    [SerializeField]
    private Button _btnBack;

    [SerializeField]
    private Button _btnExit;

    private void Start()
    {
        _btnSettings.onClick.AddListener(Settings);
        _btnBack.onClick.AddListener(Back);
        _btnExit.onClick.AddListener(Exit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnDestroy()
    {
        _btnBack.onClick.RemoveAllListeners();
        _btnSettings.onClick.RemoveAllListeners();
        _btnExit.onClick.RemoveAllListeners();
    }

    private void Settings()
    {
        _settings.SetActive(true);
    }

    private void Back()
    {
        Time.timeScale = 1;
        _pause.SetActive(false); 
    }

    private void Exit()
    {
        Application.Quit();
    }
}
