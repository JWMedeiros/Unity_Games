using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmt = 5;
    [SerializeField] AmmoType ammoType;
    public AudioClip pickupSound;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag=="Player")
        {
            //Sound Persists after death of object
            AudioSource.PlayClipAtPoint(pickupSound,transform.position);
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType,ammoAmt);
            Destroy(gameObject);
        }
    }
}
