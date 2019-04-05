using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour {

    public GameObject menu;
    public GameObject simUI;

    public Input UIInput;
    public GameObject Particle1;
    public GameObject Particle2;

    Input.ParticleSetup prevParticleSetup;

    public void StartFromUI()
    {
        Input.ParticleSetup particleSetup = UIInput.GetUserInput();
        Setup(particleSetup);

    }

    public void StartFromFile()
    {

    }
    void Setup(Input.ParticleSetup particleSetup)
    {
        Transform transformP1 = Particle1.transform;
        Rigidbody rigidbodyP1 = Particle1.GetComponent<Rigidbody>();

        Transform transformP2 = Particle2.transform;
        Rigidbody rigidbodyP2 = Particle2.GetComponent<Rigidbody>();


        transformP1.localScale = Vector3.one * particleSetup.particleArray[0].size;
        transformP1.localPosition = particleSetup.particleArray[0].position;
        rigidbodyP1.velocity = particleSetup.particleArray[0].velocity;

        transformP2.localScale = Vector3.one * particleSetup.particleArray[1].size;
        transformP2.localPosition = particleSetup.particleArray[1].position;
        rigidbodyP2.velocity = particleSetup.particleArray[1].velocity;


        prevParticleSetup = particleSetup;
        ShowMenu(false);
    }

    public void Reset()
    {
        Setup(prevParticleSetup);
    }

    public void ShowSimUI(bool enable)
    {
        simUI.SetActive(enable);
        ShowMenu(!enable);
    }

    public void ShowMenu(bool enable)
    {
        menu.SetActive(enable);
        ShowSimUI(!enable);
    }

    // Use this for initialization
    void Start () {
		
	}
}
