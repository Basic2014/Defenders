using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text timer;
    private float counter;
    private PlayerHealth playerHealth;
    private bool isDead = false;
    
   

    private void Awake()
    {
        timer = GetComponent<Text>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if(!isDead)
        {
            counter += Time.deltaTime;
            timer.text = " " + counter.ToString("0.0.0");
        }

        
        if (playerHealth.currHealth <= 0 && !isDead)
        {
            isDead = true;            
        }
       
        if(isDead)
        {
            PlayerPrefs.SetFloat("HighScore", counter);
        }

    }


}
