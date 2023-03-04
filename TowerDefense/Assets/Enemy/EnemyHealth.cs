using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    
    [Tooltip("Adds amount to max HP when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
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
        if (currentHP<=0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        //Play deathFX
        enemy.RewardGold();
        gameObject.SetActive(false);
        maxHP+= difficultyRamp;
    }

}
