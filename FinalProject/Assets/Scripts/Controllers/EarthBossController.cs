using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBossController : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private bool isMoving;
    private Transform target;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(transform.position, target.position) < 10.0f))
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            isMoving = false;
        }

        anim.SetFloat("MoveX", transform.position.x);
        anim.SetFloat("MoveY", transform.position.y);
        anim.SetBool("isMoving", isMoving);
    }
}
