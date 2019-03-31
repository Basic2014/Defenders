using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDisplay : MonoBehaviour {

    private AudioSource audio;
    private float volume;       
    
	void Start () {
        audio = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat("Volume");
        audio.volume = volume;
	}
		
}
