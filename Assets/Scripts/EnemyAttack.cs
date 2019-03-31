using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float nextFire = 0.5f;
    public int attackDmg = 10;

    
    


    private float timer;
    private bool attackDistance;
    private bool attack;
    private Animator anim;
    private EnemyMovement movement;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;


    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        movement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        
    }


    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer > nextFire && attackDistance && attack && enemyHealth.currentHealth > 0)
        {
           Attack();
        }

        anim.SetBool("Attack", attack);
       

        if (playerHealth.currHealth <=0)
        {
            attack = false;
            anim.SetTrigger("PlayerDead");
            movement.enabled = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            attackDistance = true;
            attack = true;

            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            attackDistance = false;
            attack = false;
            
        }
    }

    private void Attack()
    {
        timer = 0f;

        anim.SetBool("Attack", attack);

        if (playerHealth.currHealth >= 0 )
        {
            playerHealth.TakeDamage(attackDmg);
           

        }

    }

}
