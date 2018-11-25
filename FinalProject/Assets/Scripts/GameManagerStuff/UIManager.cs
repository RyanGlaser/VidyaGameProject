using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;
    private static bool UIExists;

	// Use this for initialization
	void Start ()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.value = playerHealth.playerCurrentHealth;
        if(healthBar.value <= 0)
            HPText.text = "Health: " + 0 + "/" + playerHealth.playerMaxHealth;
        else if(healthBar.value >= 100)
            HPText.text = "Health: " + 100 + "/" + playerHealth.playerMaxHealth;    
        else
            HPText.text = "Health: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
    }
}
