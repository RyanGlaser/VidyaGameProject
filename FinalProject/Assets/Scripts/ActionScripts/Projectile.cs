using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 target;
    public float speed;
    public int damageAmount;
	// Use this for initialization
	void Start ()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, target) < 0.001f)
            Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "WaterEdge")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealthManager>().DamageEnemy(damageAmount);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        
    }

}
