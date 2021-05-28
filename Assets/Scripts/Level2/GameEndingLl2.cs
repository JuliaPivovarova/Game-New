using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingLl2 : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private CanvasGroup _exitBackgroundImageCanvasGroup;
    [SerializeField]
    private CanvasGroup _caughtBackgroundImageCanvasGroup;
    [SerializeField]
    private CanvasGroup _deadBackgroundImageCanvasGroup;
    [SerializeField]
    private AudioSource _exitAudio;
    [SerializeField]
    private AudioSource _caughtAudio;

    private bool _isPlayerAtExit;
    private bool _isPlayerCaught;
    private bool _isPlayerDead;
    private float _timer;
    private bool _hasAudioPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _isPlayerAtExit = true;

        }
    }

    public void CaughtPlayer()
    {
        _isPlayerCaught = true;
    }

    public void DeadPlayer()
    {
        _isPlayerDead = true;
    }


    private void Update()
    {        
        if (_isPlayerAtExit)
        {
            EndLevel(_exitBackgroundImageCanvasGroup, false, _exitAudio);
        }
        else if (_isPlayerCaught)
        {
            EndLevel(_caughtBackgroundImageCanvasGroup, true, _caughtAudio);
        }
        else if (_isPlayerDead)
        {
            EndLevel(_deadBackgroundImageCanvasGroup, true, _caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!_hasAudioPlayed)
        {
            audioSource.Play();
            _hasAudioPlayed = true;
        }

        _timer += Time.deltaTime;

        imageCanvasGroup.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene("Level2");
            }
            else
            {
                //SceneManager.LoadScene("Level2");
                Application.Quit();
            }
        }
    }
}
