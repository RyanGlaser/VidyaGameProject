using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public bool isAlive = true;


	// Use this for initialization
	void Start ()
    {
        SetMaxHealth();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerCurrentHealth <= 0)
        {
            isAlive = false;
            gameObject.SetActive(false);
        }
	}

    public void DamagePlayer(int damageAmt)
    {
        if (playerCurrentHealth <= 0)
            return;
        else
            playerCurrentHealth -= damageAmt;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void HealPlayer(int healAmt)
    {
        playerCurrentHealth += healAmt;
    }
}
