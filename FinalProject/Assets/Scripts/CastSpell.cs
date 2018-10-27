using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{

    public GameObject spell;
    private Transform playerPos;

	// Use this for initialization
	void Start ()
    {
        playerPos = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            Instantiate(spell, playerPos.position, Quaternion.identity);
        }
	}
}
