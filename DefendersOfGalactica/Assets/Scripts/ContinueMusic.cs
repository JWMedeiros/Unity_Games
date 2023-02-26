using UnityEngine;

public class ContinueMusic : MonoBehaviour
{
    void Awake() {
        int numMusicPlayers = FindObjectsOfType<ContinueMusic>().Length;
        if (numMusicPlayers>1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
