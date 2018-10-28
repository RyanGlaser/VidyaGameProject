using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<NetworkHealthManager>();
        if(health != null)
        {
            health.DamagePlayer(10);
        }

        Destroy(gameObject);
    }

}
