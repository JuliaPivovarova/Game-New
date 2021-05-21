using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button _btnStart;

    [SerializeField]
    private GameObject _mainMenu;

    [SerializeField]
    private Button _btnSettings;

    [SerializeField]
    private GameObject _settings;

    [SerializeField]
    private Button _btnExit;

    [SerializeField]
    private GameObject _canvOnScreen;

    private void Awake()
    {
        Time.timeScale = 0;        
    }

    private void Start()
    {
        _btnStart.onClick.AddListener(StartGame);
        _btnExit.onClick.AddListener(Exit);
        _btnSettings.onClick.AddListener(Settings);
    }

    private void OnDestroy()
    {
        _btnStart.onClick.RemoveAllListeners();
        _btnExit.onClick.RemoveAllListeners();
        _btnSettings.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        _mainMenu.SetActive(false);
        Time.timeScale = 1;
        _canvOnScreen.SetActive(true);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Settings()
    {
        _settings.SetActive(true);
    }
}
