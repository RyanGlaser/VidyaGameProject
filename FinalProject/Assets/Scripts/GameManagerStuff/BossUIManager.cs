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
        HPText.text = "Boss Health: " + enemyHealth.enemyCurrentHealth + "/" + enemyHealth.enemyMaxHealth;
    }
}
