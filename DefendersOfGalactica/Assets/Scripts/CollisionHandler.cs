using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosion;
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log(gameObject +" Crashed with "+ other);
        StartCrashSequence();
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void StartCrashSequence()
    {
        explosion.Play();
        GetComponent<MeshRenderer>().enabled=false;
        GetComponent<BoxCollider>().enabled=false;
        GetComponent<PlayerControls>().enabled=false;
        Invoke("ReloadLevel", loadDelay);
    }
}
