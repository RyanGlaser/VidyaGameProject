using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public GameObject damageEffect1;
    public int bossNum = -1; //for win condition
    public bool isAlive = true;
    public Transform healthSpawnPos;
    public GameObject heart;
    private GameObject damageEffectTemp;

    /**
     * @author Robbae
     * @since 11/22/18
     * I addded a bossNum so I could specify who died
     * I send the info of who died to gameManager in Update()
     * NOTE: Use bossNum = -1 (default) for regular enemies EXCEPT bosses
     * 0 = Water
     * 1 = Earth
     * 2 = Fire
     * 3 = Air
     */

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
            if (bossNum > -1)
            {
                //this is to signal to our gameManager that boss is dead
                Debug.Log("Killing boss: " + bossNum);
                GameManager._instance.BossDown(bossNum);
                Debug.Log("Boss killed.");
                SpawnHealth();
            }
        }

    }

    public void DamageEnemy(int damageAmt)
    {
        if (enemyCurrentHealth <= 0)
            return;
        else
        {
            enemyCurrentHealth -= damageAmt;
            damageEffectTemp = Instantiate(damageEffect1, transform.position, transform.rotation);
            Destroy(damageEffectTemp, 2.0f);
        }
        
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void HealEnemy(int healAmt)
    {
        enemyCurrentHealth += healAmt;
    }

    public void SpawnHealth()
    {
        Instantiate(heart, healthSpawnPos.position, healthSpawnPos.rotation);
    }

  
}
