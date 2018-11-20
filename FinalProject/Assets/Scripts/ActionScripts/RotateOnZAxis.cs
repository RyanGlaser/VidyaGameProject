using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnZAxis : MonoBehaviour {

    Vector3 rotationEuler;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        rotationEuler += Vector3.forward * 30 * Time.deltaTime; //increment 30 degrees every second
        transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
