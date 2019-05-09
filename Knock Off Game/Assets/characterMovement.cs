using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class characterMovement : PhysicsObject
{
    public float maxSpeed = 15;
    public float jump = 15;
    public Animator animator;
    public bool facingRight;


    void start()
    {
        facingRight = true;
        animator.SetBool("IsBlinking", true);
    }

    protected override void ComputeVelocity()
    {

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move.x));
        Flip(move.x);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jump;
            animator.SetBool("IsJumping", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            while (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
            animator.SetBool("IsJumping", false);
        }
        /*else
		{
			animator.SetBool("IsJumping", false);
		}
		*/

        targetVelocity = move * maxSpeed;

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void Flip(float move)
    {
        if (move > 0 && !facingRight || move < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f); //new way to rotate

        }
    }
}


