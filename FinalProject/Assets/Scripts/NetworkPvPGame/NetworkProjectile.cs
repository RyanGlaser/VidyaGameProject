using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkProjectile : MonoBehaviour
{
    public int damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var health = collision.gameObject.GetComponent<NetworkHealthManager>();
            if (health != null)
            {
                health.GiveDamage(damageAmount);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }  
    }

}
