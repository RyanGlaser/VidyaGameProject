using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerController : NetworkBehaviour
{

    public float moveSpeed;
    Animator anime;
    bool isPlayerMoving;
    public Vector2 lastMove;
    Rigidbody2D playerRigidBody;
    public GameObject spellPrefab;
    Vector2 spellLocation;
    Vector2 spellTarget;
    public float spellSpeed;
    public Transform spellSpawnTop;
    public Transform spellSpawnBottom;
    private Quaternion temp;


    // Use this for initialization
    void Start ()
    {
        anime = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        
        isPlayerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
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

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
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

       
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            spellTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(spellTarget);
            if (spellTarget.y > transform.position.y)
            {
                spellLocation = spellSpawnTop.position;
                temp = spellSpawnTop.rotation;
            }
            else
            {
                spellLocation = spellSpawnBottom.position;
                temp = spellSpawnBottom.rotation;
            }
            CmdSpell(spellTarget);
        }
    }

    [Command]
    void CmdSpell(Vector2 spellTargetDir)
    {
       // Quaternion temp = Quaternion.identity;
        /*if (spellTarget.y > transform.position.y)
        {
            spellLocation = spellSpawnTop.position;
            temp = spellSpawnTop.rotation;
        }
        else
        {
            spellLocation = spellSpawnBottom.position;
            temp = spellSpawnBottom.rotation;
        }
        */
        var spell = (GameObject)Instantiate(spellPrefab, spellLocation, temp);
        
        spell.GetComponent<Rigidbody2D>().velocity = (spellTargetDir - spellLocation).normalized * spellSpeed;
        NetworkServer.Spawn(spell);

        Destroy(spell, 3.0f);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }
}
