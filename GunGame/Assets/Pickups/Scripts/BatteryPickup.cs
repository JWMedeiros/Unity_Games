using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float lightIntensityAmt=4;
    [SerializeField] float lightAngleAmt=70;

    Flashlight playerLight;

    public AudioClip pickupSound;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag=="Player")
        {
            playerLight=other.GetComponentInChildren<Flashlight>();
            playerLight.RestoreLightAngle(lightAngleAmt);
            playerLight.RestoreLightIntensity(lightIntensityAmt);
            AudioSource.PlayClipAtPoint(pickupSound,transform.position, 0.7f);
            Destroy(gameObject);
        }
    }
}
