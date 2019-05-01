using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCamera : MonoBehaviour {

    //Rigidbody rb;

    public GameObject targetToFollow;

    public Vector3 offset;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = targetToFollow.transform.position + offset;

    }
}
