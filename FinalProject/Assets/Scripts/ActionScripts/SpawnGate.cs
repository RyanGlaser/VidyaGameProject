using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject gate;
    public GameObject enemy;
    private bool gateSpawned = false;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (enemy.GetComponent<EnemyHealthManager>() == null)
        {
            Destroy(gate);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!gateSpawned)
        {
            if (collision.gameObject.tag == "Player")
            {
                gateSpawned = true;
                Debug.Log("fuck me");
                Instantiate(gate, transform.position, transform.rotation);
            }
        }
    }
}
