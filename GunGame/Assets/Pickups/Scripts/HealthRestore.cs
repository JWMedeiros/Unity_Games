using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    [SerializeField] float amt = 30f;
    public AudioClip healthSound;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(healthSound,transform.position, 0.7f);
            other.gameObject.GetComponent<PlayerHealth>().RestoreHealth(amt);
            Destroy(gameObject);
        }
    }
}
