using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlayer : MonoBehaviour {

    private Rigidbody rigid;
    private GravityReceiver planet;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityReceiver>();
        rigid.useGravity = false;
        rigid.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate () {

        planet.Receiver(rigid);

	}
}
