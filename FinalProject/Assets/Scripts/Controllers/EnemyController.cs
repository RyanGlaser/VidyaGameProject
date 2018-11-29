using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private bool isMoving;
    private Transform target;
    private SoundManager dj;
    public float distanceToAttack;
    // spell stuff for the water troopers
    public float spellSpeed;
    public float timeBetweenCastSpell;
    private float castSpellCounter;
    public GameObject spellPrefab;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<PlayerController>().transform;
        dj = SoundManager._instance;
        castSpellCounter = timeBetweenCastSpell;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if((Vector2.Distance(transform.position, target.position) < distanceToAttack))
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            CastSpell();
        }
        else
        {
            isMoving = false;
        }

        SetAnimation();
    }

    private void SetAnimation()
    {
        anim.SetFloat("MoveY", target.position.y);
        anim.SetBool("isMoving", isMoving);
    }

    private void CastSpell()
    {
        if (castSpellCounter > 0.0f)
            castSpellCounter -= Time.deltaTime;

        if (castSpellCounter < 0.0f)
        {
            Vector2 spellDir = (target.position - transform.position).normalized * spellSpeed;
            GameObject spell = Instantiate(spellPrefab, transform.position, transform.rotation);
            spell.GetComponent<Rigidbody2D>().velocity = new Vector2(spellDir.x, spellDir.y);
            dj.PlaySFX("WaterBossSFX");
            Destroy(spell, 3.0f);
            castSpellCounter = timeBetweenCastSpell;
        }
    }
}
