using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossController : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim; 
    private Vector3 moveDir;
    private bool isMoving;
    private Transform target;

    // **** spell stuffz ************* 
    public Transform[] spellSpawnPositions;
    public Transform[] spellDirections;
    public float timeBetweenCastSpell;
    public GameObject spellPrefab;
    public float spellSpeed;
    private float castSpellCounter;
    private GameObject[] spellz;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<PlayerController>().transform;
        castSpellCounter = timeBetweenCastSpell;
        spellz = new GameObject[4];
    }
	
	// Update is called once per frame
	void Update ()
    {
	   if((Vector2.Distance(transform.position, target.position) < 15.0f))
       {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (castSpellCounter > 0.0f)
                castSpellCounter -= Time.deltaTime;

            if (castSpellCounter < 0.0f)
            {
                CastSpell(); // spell counter is less than zero so we can cast the boss spell
                castSpellCounter = timeBetweenCastSpell;
            }

        }
       else
       {
            isMoving = false;
       }
        

        anim.SetFloat("MoveX", target.position.x);
        anim.SetFloat("MoveY", target.position.y);
        anim.SetBool("isMoving", isMoving);
    }

    public void CastSpell()
    {
        for (int i = 0; i < spellSpawnPositions.Length; i++)
        {
            spellz[i] = (GameObject)Instantiate(spellPrefab, spellSpawnPositions[i].position, Quaternion.identity);
            switch (i)
            {
                default:
                    break;
                case 0: // left position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = (spellDirections[i].position - spellSpawnPositions[i].position) * spellSpeed;
                    break;
                case 1: // right position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = (spellDirections[i].position - spellSpawnPositions[i].position) * spellSpeed;
                    break;
                case 2: // up position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = (spellDirections[i].position - spellSpawnPositions[i].position) * spellSpeed;
                    break;
                case 3: // down position
                    spellz[i].GetComponent<Rigidbody2D>().velocity = (spellDirections[i].position - spellSpawnPositions[i].position) * spellSpeed;
                    break;
            }
            Destroy(spellz[i], 3.0f);
        }
    }
}
