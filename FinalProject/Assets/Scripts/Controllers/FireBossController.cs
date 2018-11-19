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

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<PlayerController>().transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
	   if((Vector2.Distance(transform.position, target.position) < 15.0f))
       {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
          //  moveDir = transform.position;
       }
       else
       {
            isMoving = false;
       }
        

        anim.SetFloat("MoveX", target.position.x);
        anim.SetFloat("MoveY", target.position.y);
        anim.SetBool("isMoving", isMoving);
    }
}
