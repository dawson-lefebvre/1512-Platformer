using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 direction;
    SpriteRenderer sr;
    public float moveSpeed = 5;
    public LayerMask playerLayer;
    public float hitForce, bonkForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        direction = new Vector2(1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyReverse")
        {
            direction = new Vector2(direction.x * -1, 0);
            if (sr.flipX)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
            
        }
        else if(collision.tag == "Player")
        {
            Rigidbody2D playerRB = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            if(playerRB.velocity.y < 0)
            {
                playerRB.AddForce(new Vector2(bonkForce, bonkForce), ForceMode2D.Impulse);
                Destroy(gameObject);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hitForce, hitForce), ForceMode2D.Impulse);
            Global.health--;
        }
    }
}
