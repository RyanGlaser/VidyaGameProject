using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyMaxHealth;
    public int enemyCurrentHealth;

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
