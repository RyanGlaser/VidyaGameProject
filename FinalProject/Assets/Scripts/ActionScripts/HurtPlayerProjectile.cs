using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerProjectile: MonoBehaviour
{
    public int damageAmount;
    public GameObject damageEffect;

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
       if(collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "WaterEdge" )
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damageAmount);
                GameObject damageEffectTemp = Instantiate(damageEffect, transform.position, transform.rotation);
                Destroy(damageEffectTemp, 2.0f);
            }
            Destroy(gameObject);
        }
    }
}
