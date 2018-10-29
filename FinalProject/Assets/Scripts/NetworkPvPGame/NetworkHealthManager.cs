using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkHealthManager : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth = maxHealth;
    public RectTransform healthBar;
    private NetworkStartPosition[] spawnPoints;


    private void Start()
    {
        if(isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void GiveDamage(int dmgAmt)
    {
        if(!isServer)
        {
            return;
        }

        currentHealth -= dmgAmt;
        if(currentHealth <= 0)
        {
            if (transform.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
            currentHealth = maxHealth;

            RpcRespawn();
        }
    }

    void OnChangeHealth(int Health)
    {
        healthBar.sizeDelta = new Vector2(Health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            Vector2 spawnPoint = Vector2.zero;

            if(spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            transform.position = spawnPoint;
        }
    }
}
