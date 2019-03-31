using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Transform player;
    public float speed = 3f;
    public float walkSpeed = 5f;
    

    private Rigidbody rigid;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void FixedUpdate()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        Quaternion newRot = Quaternion.LookRotation(dir,transform.up);
        Quaternion smoothRot = Quaternion.Slerp(transform.rotation, newRot, speed * Time.deltaTime);
        rigid.MoveRotation(smoothRot);

        rigid.velocity = transform.forward * walkSpeed;

        
            


    }



}
