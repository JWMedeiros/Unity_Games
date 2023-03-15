using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void DecreaseHP(float dmg)
    {
        hitpoints-=dmg;
        if (hitpoints<=0)
        {
            Destroy(gameObject);
        }
    }
}
