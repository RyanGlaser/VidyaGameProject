using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnGate : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject gate;

    private GameManager yep;
    private string currSceneName = null;
    private bool gateSpawned = false;

    private GameObject gateTemp;

	// Use this for initialization
	void Start ()
    {
        gateSpawned = false;
        yep = GameManager._instance;
        currSceneName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gateSpawned && !yep.IsBossAlive(currSceneName))
        {
            Destroy(gateTemp);
            gateSpawned = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if gate is not spawned & boss is alive
        if(!gateSpawned && yep.IsBossAlive(currSceneName))
        {
            if (collision.gameObject.tag == "Player")
            {
                gateSpawned = true;
                Debug.Log("fuck me");
                gateTemp = Instantiate(gate, transform.position, transform.rotation);
            }
        }
    }
}