using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerMelee: MonoBehaviour
{
    public int damageAmount;
    public GameObject damageEffect;
    private float damageTime = 0.5f;
    private float damageTimer = 0;

	// Use this for initialization
	void Start ()
    {
  
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.gameObject.name != "Enemy")
        {
            if (collision.gameObject.name == "Player")
            {
                if(damageTimer >= damageTime)
                {
                    damageTimer -= damageTime;
                    collision.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damageAmount);
                    GameObject temp = Instantiate(damageEffect, collision.gameObject.transform.position, transform.rotation);
                    Destroy(temp, 1.0f);
                }
                damageTimer += Time.deltaTime; 
            }
        }
    }
}
