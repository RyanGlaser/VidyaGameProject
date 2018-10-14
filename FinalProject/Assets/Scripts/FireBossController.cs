﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private bool isMoving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDir;

	// Use this for initialization
	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDir;

            if (timeToMoveCounter < 0.0f)
            {
                isMoving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if(timeBetweenMoveCounter < 0.0f)
            {
                isMoving = true;
                timeToMoveCounter = timeToMove;
                moveDir = new Vector3(Random.Range(-1.0f, 1.0f) * moveSpeed, Random.Range(-1.0f, 1.0f) * moveSpeed, 0.0f);
            }
        }
    
	}
}
