using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int score = 15;
    [SerializeField] int killScore = 50;
    [SerializeField] int hp = 1;
    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        //Find the first Scoreboard object in the game
        //FindObjectOfType is very intensive if called every frame
        //It is not if only called once
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity=false;
    }

    //When Enemy gets hit by Particles, create explosion on enemy
    //Self Destruct it afterwards and then increase score
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        hp -= 1;
        if (hp < 1)
        {
            IncreaseScore(killScore);
            KillEnemy();
        }
        else
        {
            IncreaseScore(score);
            HitEnemy();
        }
    }

    void HitEnemy()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }

    void IncreaseScore(int score)
    {
        scoreBoard.KeepScore(score);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}
