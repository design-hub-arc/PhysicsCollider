using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOmniVision : MonoBehaviour {

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
    }

    void Move()
    {
        centerPoint = GetCenter();

        newPosition = centerPoint + offset;

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
        }
        else
        {
            greatestDistance = bounds.size.y;
        }

        return greatestDistance;
    }

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

    //the closer you are the higher the boundry
    public float closenessBoundry;

    //if the particle is moving closer move away depending on how far the boundry is
    void ParticleMovingTowardsCamera()
    {
        for(int i = 0; i < ParticleList.Count; i++)
        {
            print(ParticleList[i].transform.position.z - gameObject.transform.position.z);
            if (ParticleList[i].transform.position.z - gameObject.transform.position.z > closenessBoundry)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                            gameObject.transform.position.y,
                                                            gameObject.transform.position.z + (closenessBoundry - (ParticleList[i].transform.position.z - gameObject.transform.position.z)));
            }
        }
    }

}
