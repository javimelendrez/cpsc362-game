using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection; //character only moves horizontal so x direction no need for y
    Rigidbody2D r;
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (r.position.x == 38.7049)
        {
            XMoveDirection = -1;

        }else if(r.position.x < 33.32)
        {
            XMoveDirection = 1;

        }
    }
    public void die()
    {
        Destroy(gameObject);
    }
}


