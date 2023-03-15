using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage= 20;
    [SerializeField] GameObject hitEffect;
    AudioSource audioSource;

    [SerializeField] ParticleSystem fireVFX;

    [SerializeField] StarterAssets.StarterAssetsInputs inputs;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (inputs.fire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Only shoot once and then turns input off after click, doesn't work for automatic weapons
        inputs.fire = false;
        ProcessRaycast();
        PlaySound();
        PlayMuzzleFlash();
    }

    void ProcessRaycast()
    {
        //Shoots out invisible raycast from the camera to the specified range, comes back with hit information
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target)
            {
                target.DecreaseHP(damage);
            }
        }
        else
        {
            return;
        }
    }
    void PlayMuzzleFlash()
    {
        fireVFX.Play();
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact,1);
    }
    void PlaySound()
    {
        audioSource.Play();
    }
}
