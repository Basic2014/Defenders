using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    public int startHealth = 100;
    public int currHealth;
    public Slider healthSlider;
    public AudioClip deathSound;
    public Image hurtImg;
    public float speed = 0.2f;

    private AudioSource audio;
    private bool isDead, hurt;


    private void Awake()
    {
        currHealth = startHealth;
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(hurt)
        {
            hurtImg.color = new Color(0.3f, 0.1f, 0.1f, 0.2f);
        }

        else
        {
            hurtImg.color = Color.Lerp(hurtImg.color, Color.clear, speed * Time.deltaTime);
        }

        hurt = false;


    }



    public void TakeDamage(int damage)
    {

        hurt = true;

        currHealth -= damage;
        healthSlider.value = currHealth;

        audio.Play();

        if(currHealth <= 0 && !isDead)
        {
            Die();
        }


    }

    private void Die()
    {
        isDead = true;

        audio.clip = deathSound;
        audio.Play();
        
        transform.gameObject.SetActive(false);
       

    }
  



}
