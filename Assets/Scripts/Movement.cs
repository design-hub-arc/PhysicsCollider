using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector3 startingCoordinates;

    public Vector3 stepVelocity;


    //For later if we use formula
    //Vector3 startCoordinatesMultiplier
    //float intialCoordinate

    //Vector3 velocityMultiplier
    //float InitialVelocity;


    // Use this for initialization
    void Start () {
        transform.position = startingCoordinates;

        /* Initialization of starting coordinates and stepVelocity
        startingCoordinates = new Vector3(startCoordinatesMultiplier.x * intialCoordinate, 
                                          startCoordinatesMultiplier.y * intialCoordinate, 
                                          startCoordinatesMultiplier.z * intialCoordinate);

        stepVelocity = new Vector3(velocityMultiplier.x * InitialVelocity,
                                          velocityMultiplier.y * InitialVelocity,
                                          velocityMultiplier.z * InitialVelocity);
        */

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += stepVelocity;
	}
}
