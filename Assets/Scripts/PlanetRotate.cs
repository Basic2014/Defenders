using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour {

    public float speed;

	
	
	
	void Update () {

        transform.Rotate(Vector3.up * speed);


	}
}
