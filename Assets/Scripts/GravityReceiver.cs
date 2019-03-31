using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReceiver : MonoBehaviour {

    public float gravity = -10f;


    public void Receiver(Rigidbody player)
    {

        Vector3 dir = (player.position - transform.position).normalized;
        Vector3 localUp = player.transform.up;

        player.rotation = Quaternion.FromToRotation(localUp, dir) * player.rotation;

        player.AddForce(dir * gravity);

    }


}
