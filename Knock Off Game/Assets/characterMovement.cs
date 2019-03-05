using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : PhysicsObject
{
	public float maxSpeed = 15;
	public float jump = 15;

	void start()
	{

	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis("Horizontal");
		if(Input.GetButtonDown("Jump") && grounded)
		{
			velocity.y = jump;
		}
		else if(Input.GetButtonUp("Jump"))
		{
			if(velocity.y > 0)
			{
				velocity.y = velocity.y * .5f;
			}
		}

		targetVelocity = move * maxSpeed;
	}
}

