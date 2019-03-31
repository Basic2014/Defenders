using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSet : MonoBehaviour {

    private Slider slider;

    private float volume;

	void Start () {

        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {

        volume = slider.value;
        PlayerPrefs.SetFloat("Volume", volume);

	}
}
