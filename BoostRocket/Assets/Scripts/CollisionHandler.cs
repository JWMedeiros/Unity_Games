using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crashSfx;
    [SerializeField] AudioClip finishSfx;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    bool canCollide = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        DetectCheats();
    }

    void DetectCheats()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            FlipCollisions();
        }
    }

    void FlipCollisions()
    {
        if (canCollide)
        {
            canCollide = false;
        }
        else
        {
            canCollide = true;
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || !canCollide) {return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartCrashSequence();
                break;

        }
    }

    void StartFinishSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        finishParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(finishSfx);
        Invoke("LoadNextLevel",delay);

    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crashSfx);
        Invoke("ReloadLevel", delay);
    }

    public void LoadNextLevel()
    {
        if (GetCurrentScene()==SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(GetCurrentScene()+1);
        }
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(GetCurrentScene());
    }

    int GetCurrentScene ()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
