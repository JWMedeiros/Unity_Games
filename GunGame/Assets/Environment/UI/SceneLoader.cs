using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale=1;
    }
    public void QuitGame()
    {
        //If application doesnt quit, re-enable the timescale here too.
        Application.Quit();
    }
}
