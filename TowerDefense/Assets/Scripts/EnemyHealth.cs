using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    Enemy enemy;
    int currentHP=0;

    void Start()
    {
        enemy=GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHP = maxHP;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP--;
        if (currentHP<1)
        {
            KillEnemy();
        }
        else
        {
            HitEnemy();
        }
    }

    void KillEnemy()
    {
        //Play deathFX
        enemy.RewardGold();
        gameObject.SetActive(false);
    }

    void HitEnemy()
    {
        //Get money, play hitfx
    }
}
