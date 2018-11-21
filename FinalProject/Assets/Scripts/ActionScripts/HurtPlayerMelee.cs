using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerMelee: MonoBehaviour
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
       if(collision.gameObject.name != "Enemy")
        {
            if (collision.gameObject.name == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damageAmount);
                Instantiate(damageEffect, collision.gameObject.transform.position, transform.rotation);
            }
        }
    }
}
