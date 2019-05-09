using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        enemyVertical e = collision.GetComponent<enemyVertical>();
        EnemyMove a = collision.GetComponent<EnemyMove>();
        if (collision.CompareTag("bad guy"))
        {
            e.die();
            
            Destroy(gameObject);

        }
        if (collision.CompareTag("boxes"))
        {
            Destroy(gameObject);

        }
        if(collision.CompareTag("bad guy2"))
        {
            a.die();
            Destroy(gameObject);
        }
    }
}
