using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Input : MonoBehaviour
{
    public InputField p1size;
    public InputField p1posX;
    public InputField p1posY;
    public InputField p1posZ;
    public InputField p1Vx;
    public InputField p1Vy;
    public InputField p1Vz;
    public InputField p2size;
    public InputField p2posX;
    public InputField p2posY;
    public InputField p2posZ;
    public InputField p2Vx;
    public InputField p2Vy;
    public InputField p2Vz;
    public InputField dimension;  //Should we remove this?

    public struct ParticleDetails
    {
        public string name;
        public float size;
        public Vector3 velocity;
        public Vector3 position;
    }

    public struct ParticleSetup
    {
        public ParticleDetails[] particleArray;
        public float dimension;
    }
    
    public ParticleSetup GetUserInput()
    {
        ParticleSetup pSetup = new ParticleSetup();
        pSetup.particleArray = new ParticleDetails[2];

        pSetup.dimension = GetInputFieldFloat(dimension);

        pSetup.particleArray[0].name = "Particle 1";
        pSetup.particleArray[0].size = GetInputFieldFloat(p1size);
        pSetup.particleArray[0].position = new Vector3(GetInputFieldFloat(p1posX),
                                                       GetInputFieldFloat(p1posY),
                                                       GetInputFieldFloat(p1posZ));

        pSetup.particleArray[0].velocity = new Vector3(GetInputFieldFloat(p1Vx),
                                                       GetInputFieldFloat(p1Vy),
                                                       GetInputFieldFloat(p1Vz));

        pSetup.particleArray[1].name = "Particle 2";
        pSetup.particleArray[1].size = GetInputFieldFloat(p2size);
        pSetup.particleArray[1].position = new Vector3(GetInputFieldFloat(p2posX),
                                                       GetInputFieldFloat(p2posY),
                                                       GetInputFieldFloat(p2posZ));

        pSetup.particleArray[1].velocity = new Vector3(GetInputFieldFloat(p2Vx),
                                                       GetInputFieldFloat(p2Vy),
                                                       GetInputFieldFloat(p2Vz));

        if(pSetup.particleArray[0].position == pSetup.particleArray[1].position)
        {
            Debug.LogWarning("Positions of multiple particles are the same");         //cancel starts
        }

        return pSetup;
    }

    private float GetInputFieldFloat(InputField field)
    {
        float fData = float.NaN;
        try
        {
            fData = float.Parse(field.text);
        }
        catch (System.Exception)
        {
            Debug.Log(field.name + " invalid");
        }

        return fData;
    }


}
