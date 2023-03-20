using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmt;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmt--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmt)
    {
        GetAmmoSlot(ammoType).ammoAmt+=ammoAmt;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
       return GetAmmoSlot(ammoType).ammoAmt;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType==ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
