using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;
    public float distance = 100f;
    public LayerMask myLayer;
    public float turnSpeed = 5f;

    private Rigidbody rigid;
    private Vector3 movement;
    private Vector3 moveTarget;
    private Vector3 smoothVelocity;
    private Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        RotatePlayer();
        AnimatePlayer(h, v); 
        

    }

    private void Move(float h, float v)
    {
        movement = new Vector3(h, 0, v).normalized;
        movement = movement * speed * Time.deltaTime;
        moveTarget = Vector3.SmoothDamp(moveTarget, movement, ref smoothVelocity, .10f);

        rigid.MovePosition(rigid.position + transform.TransformDirection(moveTarget));
    }

    void RotatePlayer()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, myLayer))
        {
            Vector3 dir = hit.point - transform.position;
           
            Quaternion newRot = Quaternion.LookRotation(dir,transform.up);
            Quaternion smoothRot = Quaternion.Slerp(transform.rotation, newRot, turnSpeed * Time.deltaTime);
            rigid.MoveRotation(smoothRot);
        }

    }

    void AnimatePlayer(float h, float v)
    {
        if (h != 0 || v != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

    }
}
