using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void DecreaseHP(float dmg)
    {
        //Broadcast to all scripts that you have been attacked, Handled differently per script that might need to know info
        BroadcastMessage("OnDamageTaken");
        hitpoints-=dmg;
        if (hitpoints<=0)
        {
            Destroy(gameObject);
        }
    }
}
