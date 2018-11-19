using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBossController : MonoBehaviour
{

    public float moveSpeed;
    private Animator anim; 
    private bool isMoving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDir;
    public Transform[] movementPositions;
    private Transform moveTarget;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
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

        anim.SetFloat("MoveX",moveDir.x);
        anim.SetFloat("MoveY", moveDir.y);
        anim.SetBool("isMoving", isMoving);
    }
}
