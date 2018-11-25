using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerProjectile: MonoBehaviour
{
    public int damageAmount;
    public GameObject damageEffect;

    private GameObject damageEffectTemp;

	// Use this for initialization
	void Start ()
    {
  
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.name == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damageAmount);
                damageEffectTemp = Instantiate(damageEffect, transform.position, transform.rotation);

                if(gameObject.tag != "Enemy")
                    Destroy(gameObject);
                
                Destroy(damageEffectTemp, 2.0f);
            }
        }
    }
}
