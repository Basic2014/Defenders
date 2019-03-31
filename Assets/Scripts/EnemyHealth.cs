using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;
    public AudioClip deathSound;

   
    private Animator anim;
    private AudioSource audio;
    private ParticleSystem particle;
    private CapsuleCollider col;
    private EnemyMovement enemyMovement;

    private bool isDead;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        particle = GetComponentInChildren<ParticleSystem>();
        col = GetComponent<CapsuleCollider>();
        enemyMovement = GetComponent<EnemyMovement>();
        currentHealth = startHealth;
    }

    public void TakeDamage(int dmg,Vector3 hitPoint)
    {
        if (isDead)
            return;

        audio.Play();
        currentHealth -= dmg;

        particle.transform.position = hitPoint;
        particle.Play();

        if(currentHealth <=0)
        {
            Die();
        }

    }

    void Die()
    {
        isDead = true;
        //col.enabled = false;
        enemyMovement.enabled = false;
        //col.isTrigger = true;
        anim.SetTrigger("EnemyDead");
        audio.clip = deathSound;
        audio.Play();
    }


}
