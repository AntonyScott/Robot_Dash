using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour {
    
    // AudioMixer is assigned to the audioMixer variable
    public AudioMixer audioMixer;
    
    // this is used to set the volume as a float number (decimal) and is then used to control it in the audioMixer
	public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
