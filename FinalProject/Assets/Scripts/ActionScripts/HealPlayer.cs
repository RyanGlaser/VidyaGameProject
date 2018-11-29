using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int healAmount;
    private SoundManager dj;

	// Use this for initialization
	void Start ()
    {
        dj = SoundManager._instance;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dj.PlaySFX("Health");
            collision.gameObject.GetComponent<PlayerHealthManager>().HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
