using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour{

    public AudioMixer audioMixer;
    
    public void SetMusicVolume(float volume){
        audioMixer.SetFloat("music", volume);
    }

    public void SetSoundVolume(float volume){
        audioMixer.SetFloat("sound", volume);
    }
}
