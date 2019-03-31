using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float height, length;
    public float damp, rotationDamp;
   

	void Start () {
      
	}

    private void FixedUpdate()
    {
        Vector3 nextPos = player.TransformPoint(0, height, -length);
        transform.position = Vector3.Lerp(transform.position, nextPos, damp * Time.deltaTime);

        Vector3 dif = player.position - transform.position;
        Quaternion nextRot = Quaternion.LookRotation(dif, player.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, nextRot, rotationDamp * Time.deltaTime);


    }



}
