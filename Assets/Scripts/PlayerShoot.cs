using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public float nextFire = 0.2f;
    public int damage = 25;
    public float distance = 200f;


    private float timer;
    private AudioSource audio;
    private ParticleSystem particle;
    private Light light;
    private LineRenderer lineRenderer;
    private float effectTime = 0.2f;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        light = GetComponent<Light>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire1") && timer > nextFire)
        {
            Shoot();
        }
        
        if(timer > nextFire * effectTime)
        {
            lineRenderer.enabled = false;
            light.enabled = false;
        }

    }


    void Shoot()
    {
        timer = 0f;
        audio.Play();

        light.enabled = true;

        particle.Stop();
        particle.Play();

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);

        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if(Physics.Raycast(ray,out hit,distance))
        {

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, hit.point);
            }

            lineRenderer.SetPosition(1, hit.point);

        }




    }

}
