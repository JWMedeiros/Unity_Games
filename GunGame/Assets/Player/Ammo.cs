using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmt = 10;

    public void ReduceCurrentAmmo()
    {
        ammoAmt-=1;
    }

    public int GetCurrentAmmo()
    {
        return ammoAmt;
    }
}
