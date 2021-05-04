using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField]
    private CanvasGroup caughtBackgroundImageCanvasGroup;
    [SerializeField]
    private CanvasGroup deadBackgroundImageCanvasGroup;
    [SerializeField]
    private AudioSource exitAudio;
    [SerializeField]
    private AudioSource caughtAudio;

    private bool m_IsPlayerAtExit;
    private bool m_IsPlayerCaught;
    private bool m_IsPlayerDead;
    private float m_Timer;
    private bool m_HasAudioPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;

        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    public void DeadPlayer()
    {
        m_IsPlayerDead = true;
    }


    void Update()
    {        
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
        else if (m_IsPlayerDead)
        {
            EndLevel(deadBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene("Level1");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
