using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBossController : MonoBehaviour
{ 
    // ******* movement stuffz ************
    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;
    public Transform[] movementPositions;
    private bool isMoving;
    private float timeToMoveCounter;
    private Vector3 moveDir;
    private Transform moveTarget;
    private float timeBetweenMoveCounter;

    // **** spell stuffz ************* 
    public Transform[] spellSpawnPositions;
    public float timeBetweenCastSpell;
    public GameObject spellPrefab;
    public float spellSpeed;
    private float castSpellCounter;
    private GameObject[] spellz;
    private Transform target;



    // **** animator object **************
    private Animator anim;
    
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
        castSpellCounter = timeBetweenCastSpell;
        target = GameObject.FindWithTag("Player").GetComponent<PlayerController>().transform;
        spellz = new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, moveTarget.position, moveSpeed * Time.deltaTime);
            
            if (timeToMoveCounter < 0.0f)
            {
                isMoving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            if (timeBetweenMoveCounter < 0.0f)
            {
                isMoving = true;
                timeToMoveCounter = timeToMove;
                moveTarget = movementPositions[Random.Range(0, movementPositions.Length)];
                moveDir = moveTarget.position;
            }
        }

        if ((Vector2.Distance(transform.position, target.position) < 15.0f))
        {
            if (castSpellCounter > 0.0f)
                castSpellCounter -= Time.deltaTime;

            if (castSpellCounter < 0.0f)
            {
                CastSpell(); // spell counter is less than zero so we can cast the boss spell
                castSpellCounter = timeBetweenCastSpell;
            }
        }
    
        SetAnimation(); // this sets the npc's animation object to the correct movement
    }


    private void CastSpell()
    {
        for(int i = 0; i < spellSpawnPositions.Length; i++)
        {
            spellz[i] = (GameObject)Instantiate(spellPrefab, spellSpawnPositions[i].position, Quaternion.identity);
            switch (i)
            {
                default:
                    break;
                case 0: // left position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = Vector2.left * spellSpeed;
                    break;
                case 1: // right position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = Vector2.right * spellSpeed;
                    break;
                case 2: // up position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = Vector2.up * spellSpeed;
                    break;
                case 3: // down position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = Vector2.down * spellSpeed;
                    break;
            }
            Destroy(spellz[i], 3.0f);
        }
            
    }

    private void SetAnimation()
    {
        anim.SetFloat("MoveX", moveDir.x);
        anim.SetFloat("MoveY", moveDir.y);
        anim.SetBool("isMoving", isMoving);
    }
}
