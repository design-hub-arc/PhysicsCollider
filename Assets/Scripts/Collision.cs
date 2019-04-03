using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public float timeScale = 0.15f;
    public Vector3 speed;
    //public float speedX;
    //public float speedY;
    //public float speedZ;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 movement = speed; //new Vector3(speedX, speedY, speedZ);
         
        rb.velocity = movement * 10;
                                       
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(this.name + " collision with " + collision.transform.name + " @ " + this.transform.position + "; Contact point: " + collision.contacts[0].point + "\n");
        Time.timeScale = timeScale;
        Time.maximumDeltaTime = timeScale;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
		
	}
}
