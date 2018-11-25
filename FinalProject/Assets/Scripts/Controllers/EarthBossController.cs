using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBossController : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private bool isMoving;
    private Transform target;

    // ***** spell stuffz************
    public float timeBetweenCastSpell;
    private float castSpellCounter;
    public GameObject spellPrefab;
    public Transform spellSpawnPos;
    private SoundManager dj;
    public float spellSpeed;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<PlayerController>().transform;
        dj = SoundManager._instance;
        castSpellCounter = timeBetweenCastSpell;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(transform.position, target.position) < 10.0f))
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (castSpellCounter > 0.0f)
                castSpellCounter -= Time.deltaTime;

            if (castSpellCounter < 0.0f)
            {
                Vector2 spellDir = (target.position - spellSpawnPos.position).normalized * spellSpeed;
                CastSpell(spellDir); // spell counter is less than zero so we can cast the boss spell
                castSpellCounter = timeBetweenCastSpell;
            }
        }
        else
        {
            isMoving = false;
        }

        SetAnimation();
    }

    public void CastSpell(Vector2 spellDirection)
    {
        GameObject spell = Instantiate(spellPrefab, spellSpawnPos.position, spellSpawnPos.rotation);
        spell.GetComponent<Rigidbody2D>().velocity = new Vector2(spellDirection.x, spellDirection.y);
        dj.BossAttackSFX("EarthBossSFX");
        Destroy(spell, 3.0f);
    }

    private void SetAnimation()
    {
        anim.SetFloat("MoveX", transform.position.x);
        anim.SetFloat("MoveY", transform.position.y);
        anim.SetBool("isMoving", isMoving);
    }
}
