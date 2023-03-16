using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    void Start() 
    {
        gameOverCanvas.enabled=false;
    }

    public void HandleDeath()
    {
        //Stop time, bring up GO screen and cursor for player
        gameOverCanvas.enabled=true;
        Time.timeScale=0;
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
    }
}