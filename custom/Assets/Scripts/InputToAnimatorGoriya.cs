using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimatorGoriya : MonoBehaviour {


	Animator animator;
	Rigidbody rb;
	float xx;
	float yy;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		xx = 0.0f;
		yy = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{

		//Run
		if (xx != rb.velocity.x || yy != rb.velocity.y) {
			animator.SetFloat ("horizontal_input", rb.velocity.x);
			animator.SetFloat ("vertical_input", rb.velocity.y);
			xx = rb.velocity.x;
			yy = rb.velocity.y;
		} else {
			animator.SetFloat ("horizontal_input", 0.0f);
			animator.SetFloat ("vertical_input", 0.0f);
		}


		if (rb.velocity.x == 0 && rb.velocity.y == 0)
		{
			animator.speed = 0.0f;
		}
		else
		{
			animator.speed = 1.0f;
		}
			
	}
		
}
