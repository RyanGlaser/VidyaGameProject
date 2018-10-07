using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    Animator anime;
    bool isPlayerMoving;
    Vector2 lastMove;
    Rigidbody2D playerRigidBody;

	// Use this for initialization
	void Start ()
    {
        anime = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        isPlayerMoving = false;

		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidBody.velocity.y);
            isPlayerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0f);

        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            isPlayerMoving = true;
            lastMove = new Vector2(0.0f, Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            playerRigidBody.velocity = new Vector2(0.0f, playerRigidBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0.0f);
        }

        anime.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anime.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anime.SetBool("isPlayerMoving", isPlayerMoving);
        anime.SetFloat("LastMoveX", lastMove.x);
        anime.SetFloat("LastMoveY", lastMove.y);
    }
}
