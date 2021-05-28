using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioChange : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _masterAudio;

    [SerializeField]
    private Slider _sounds;

    [SerializeField]
    private float _slToAudioMaximize;

    public float _masterLvl;

    public void SetMasterVolume()
    {
        _masterLvl = Mathf.Log(_sounds.value) * _slToAudioMaximize;
        _masterAudio.SetFloat("MyExposedParam", _masterLvl);
    }
}
