using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageAmount;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damageAmount);
        }
    }
}
