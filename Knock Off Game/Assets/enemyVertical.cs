using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyVertical : MonoBehaviour
{
	public float freq;
	public float amp;
	Vector3 posOffset = new Vector3();
	Vector3 tempPos = new Vector3();
	void Start()
	{
		posOffset = transform.position;
	}
	void Update()
	{
		tempPos = posOffset;

		transform.position = new Vector3(transform.position.x, tempPos.y + Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * amp, transform.position.z);
	}
}


