using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance=150;
    [SerializeField] int currentBalance;
    public int CurrentBalance{get{return currentBalance;}}

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake() {
        currentBalance=startingBalance;    
        UpdateDisplay();
    }
    
    public void Deposit(int amt)
    {
        currentBalance+= Mathf.Abs(amt);
        UpdateDisplay();
    }

    public void Withdraw (int amt)
    {
        currentBalance-=Mathf.Abs(amt);
        UpdateDisplay();
        if (currentBalance<0)
        {
            //Lose the game;
            ReloadScene();
        }
        //Win Level can be implemented too.
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: "+currentBalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
