using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lightDecay=.1f;
    [SerializeField] float angleDecay=0.7f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    void Start() 
    {
        myLight=GetComponent<Light>();
    }

    void Update() 
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();    
    }

    public void RestoreLightAngle(float amt)
    {
        myLight.spotAngle=amt;
    }

    public void RestoreLightIntensity(float amt)
    {
        myLight.intensity+=amt;
    }

    void DecreaseLightAngle()
    {
        if (myLight.spotAngle<=minAngle) {return;}
        myLight.spotAngle-=angleDecay*Time.deltaTime;
    }

    void DecreaseLightIntensity()
    {
        myLight.intensity-=lightDecay*Time.deltaTime;
    }
}
