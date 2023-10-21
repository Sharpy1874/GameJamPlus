using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer buttonMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        buttonMixer.SetFloat("volume", volume);
    }
}
