using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public GameObject damageEffect;

    // Use this for initialization
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageEnemy(int damageAmt)
    {
        enemyCurrentHealth -= damageAmt;
        Instantiate(damageEffect, transform.position, transform.rotation);
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void HealEnemy(int healAmt)
    {
        enemyCurrentHealth += healAmt;
    }

  
}
