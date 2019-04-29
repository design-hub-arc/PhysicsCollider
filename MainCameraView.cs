using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraView : MonoBehaviour {

    /*
     * This class is meant to be attached the main camera. 
     * The Camera is meant to be facing at a eular angle of 0,0,0
     * 
     * 
     */

    public List<GameObject> ParticleList;

    public Vector3 offset;

    Vector3 centerPoint;
    Vector3 newPosition;

    Camera camera;

	// Use this for initialization
	void Start () {
        camera = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Move();
        ParticleMovingTowardsCamera();
        //KeepParticlesInView(); //not working atm
    }

    void Move()
    {
        centerPoint = GetCenter();

        newPosition = centerPoint + offset;

        //Keeps the objects in view
        newPosition = new Vector3(newPosition.x + offset.x, newPosition.y + offset.y, offset.z - GetGreatestDistance());

        gameObject.transform.position = newPosition;


    }

    float GetGreatestDistance()
    {
        //return value 
        float greatestDistance;

        //instantiate first instance of bounds -- if it is only one it would have returned
        Bounds bounds = new Bounds(ParticleList[0].transform.position, Vector3.zero);

        //starts at 1 because previous adds the first 
        for (int i = 1; i < ParticleList.Count; i++)
        {
            //contain the transform of the particle
            bounds.Encapsulate(ParticleList[i].transform.position);
        }

        //determine which side is bigger
        if (bounds.size.x > bounds.size.y)
        {
            greatestDistance = bounds.size.x;
            print("Bounds x: " + bounds.size.x);
        }else{
            greatestDistance = bounds.size.y;

        }

        return greatestDistance;
    }



    //mostly done with bounding box becuase lazy
    Vector3 GetCenter()
    {
        //if particle list doesn't contain anything
        //maybe return vector3.zero

        //if particle list is only one particle
        if (ParticleList.Count == 1)
        {
            //if it is the only one it is the center
            return ParticleList[0].transform.position;
        }

        //instantiate first instance of bounds -- if it is only one it would have returned
        Bounds bounds = new Bounds(ParticleList[0].transform.position, Vector3.zero);
           
        //starts at 1 because previous adds the first 
        for (int i = 1; i < ParticleList.Count; i++)
        {
            //contain the transform of the particle
            bounds.Encapsulate(ParticleList[i].transform.position);
        }

        //return bounds
        return bounds.center;

    }

    GameObject closestParticle;

    void FindClosestParticle(){
        //if there is no closest particle yet add the first one
        if(closestParticle == null)
        {
            closestParticle = ParticleList[0];

            //could add another check to make sure the closestParticle recieved a particle

        }
        else if (closestParticle != null)
        {

            //iterate through each particle
            for (int i = 0; i < ParticleList.Count; i++)
            {
                //compare each particle against the closest particle
                if (CalculateDistance(ParticleList[i].transform.position.z, transform.position.z) < CalculateDistance(closestParticle.transform.position.z, transform.position.z))
                {
                    //if it is closer than that particle is the new closestParticle
                    closestParticle = ParticleList[i];
                }
            }
        }
        
    }

    float CalculateDistance(float position1, float position2)
    {
        return position1 - position2;//Mathf.Sqrt(Mathf.Pow(position1, 2) - Mathf.Pow(position2, 2));
    }

    public float closeLimit;

    //if the particle is moving closer move away depending on how far the boundry is
    void ParticleMovingTowardsCamera()
    {
        FindClosestParticle();


        if (CalculateDistance(closestParticle.transform.position.z, transform.position.z) < closeLimit)
        {
            //add the difference of the the closeLimit and the distance from camera
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z - (closeLimit - (CalculateDistance(closestParticle.transform.position.z, gameObject.transform.position.z))));
        }
    }

    /*
     * This is a piece of code meant to take over the whole functionality  by calculating the fustrum with the current distance of each particle to determine if it is within the current fustrum
     * If it isn't within the fustrum then there would be a calculation which gets the distance required to encapsulate both objects inside the view
     * 
    void KeepParticlesInView()
    {
        for (int i = 0; i < ParticleList.Count; i++)
        {
            //calculate y distance to calculate
            float frustumHeight = 2.0f * CalculateDistance(ParticleList[i].transform.position.y, transform.position.y) * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);

            //calculate x
            float frustumWidth = 2.0f * CalculateDistance(ParticleList[i].transform.position.x, transform.position.x) * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);

            //calculate required distance to give specified height/width
            float distanceHeight = frustumHeight * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);

            float distanceWidth = frustumWidth * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);

            //subtract requiredDistance... if facing a specific way might need to do do something different... might be better to make a gameobject to act a center and rotate around that

            float greatestDistance;

            if (distanceHeight > distanceWidth)
            {
                greatestDistance = distanceHeight;
            }
            else
            {
                greatestDistance = distanceWidth;
            }

            if (greatestDistance > transform.position.z)
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, greatestDistance + offset.z);
            }
        }
    }*/
}