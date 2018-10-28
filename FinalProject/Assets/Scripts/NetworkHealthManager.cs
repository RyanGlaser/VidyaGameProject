using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkHealthManager : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth;
	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void DamagePlayer(int dmgAmt)
    {
        currentHealth -= dmgAmt;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead: ");
        }
    }
}
