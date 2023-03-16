using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamageTaken()
    {
        //This can be used to do things like speed up atk animation or interrupt it if it takes dmg during attacking.
        Debug.Log("Recieving Msg");
    }

    public void AttackHitEvent()
    {
        if (target==null) {return;}
        target.TakeDamage(damage);
        Debug.Log("sfdadf");
    }

}
