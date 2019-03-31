using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeOut : MonoBehaviour {

    public float fadeTime;

    
    private Image fadeImage;
    private Color myColor = Color.black;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    void Update () {

        if(Time.timeSinceLevelLoad < fadeTime)
        {
            float alpha = Time.deltaTime / fadeTime;
            myColor.a -= alpha;
            fadeImage.color = myColor;

        }
        else
        {
            gameObject.SetActive(false);
        }

    }



}
