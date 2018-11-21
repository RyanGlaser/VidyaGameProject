using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageAmount;
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().DamageEnemy(damageAmount);
            Destroy(gameObject);
        }   
    }
}
