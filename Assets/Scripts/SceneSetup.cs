using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour {

    public Input UIInput;
    public GameObject Particle1;
    public GameObject Particle2;

    void StartFromUI()
    {
        Input.ParticleSetup particleSetup = UIInput.GetUserInput();
    }

    void StartFromFile()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
}
