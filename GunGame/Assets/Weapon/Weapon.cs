using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage= 20;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    [SerializeField] AudioSource shootSound;

    [SerializeField] AudioSource emptySound;

    [SerializeField] ParticleSystem fireVFX;

    [SerializeField] StarterAssets.StarterAssetsInputs inputs;

    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot=true;

    void OnEnable() 
    {
        //Exploitable, you can swap weapons to cancel shooting delay
        canShoot=true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButton(0)&&canShoot==true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        ammoText.text=ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    //Only shoot once and then turns input off after click, doesn't work for automatic weapons
    IEnumerator Shoot()
    {
        //inputs.fire = false;
        canShoot=false;
        if (ammoSlot.GetCurrentAmmo(ammoType)>0)
        {
            ProcessRaycast();
            shootSound.Play();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        else
        {
            emptySound.Play();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot=true;
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
}
