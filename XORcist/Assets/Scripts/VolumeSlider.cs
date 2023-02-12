using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;

    public void setVolume(float val) 
    {
        mixer.SetFloat("volume", Mathf.Log10(val)*20);
    }
}
