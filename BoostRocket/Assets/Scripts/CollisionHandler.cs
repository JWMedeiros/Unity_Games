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
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning) {return;}

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

    void LoadNextLevel()
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
