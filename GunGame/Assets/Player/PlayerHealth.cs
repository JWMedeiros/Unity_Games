using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText;

    public void TakeDamage(float damage)
    {
        hitPoints-=damage;
        ChangeHPText();
        if (hitPoints<=0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void RestoreHealth(float hp)
    {
        hitPoints+=hp;
        if (hitPoints>100f)
        {
            hitPoints=100f;
        }
        ChangeHPText();
    }

    private void ChangeHPText()
    {
        healthText.text = "HP: " + hitPoints;
        if (hitPoints <= 30)
        {
            healthText.color = Color.red;
        }
        else if (hitPoints > 30 && hitPoints <= 70)
        {
            healthText.color = Color.yellow;
        }
        else
        {
            healthText.color = Color.white;
        }
    }
}
