using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public EnemyHealthManager enemyHealth;

    // Use this for initialization
    void Start ()
    {
        healthBar.maxValue = enemyHealth.enemyMaxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.value = enemyHealth.enemyCurrentHealth;
        if (healthBar.value <= 0)
        {
            HPText.text = "Boss Health: " + 0 + "/" + enemyHealth.enemyMaxHealth;
        }
        else
            HPText.text = "Boss Health: " + enemyHealth.enemyCurrentHealth + "/" + enemyHealth.enemyMaxHealth;
    }
}
