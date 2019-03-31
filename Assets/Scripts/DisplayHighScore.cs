using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

    private Text highScore;
    private float score;

	void Start () {

        highScore = GetComponent<Text>();
        score = PlayerPrefs.GetFloat("HighScore");
        highScore.text = " " + score.ToString("0.0.0") + " seconds";
	}
		
}
