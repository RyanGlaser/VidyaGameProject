using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetWorkEnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            var spawnPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-6.0f, 6.0f));

            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            NetworkServer.Spawn(enemy);
        }
    }
       
}
