using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalfosMovement : MonoBehaviour {

	// Inspector Fields
	public float movement_speed = 4;
	public Vector2 current_input;

	Rigidbody rb;
	Transform tf;

	private float horizontal_input;
	private float vertical_input;
	private float correct_position_x;
	private float correct_position_y;
	private bool if_go=true;

	// Use this for initialization
	void Start () {
		//Store a reference to the Rigidbody component on this game object
		//This prevents us from calling GetComponet() every frame, which save performance.
		rb = GetComponent<Rigidbody>();
		tf = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		if (if_go == true) {
			StartCoroutine (GetInputForSeconds ());
		}
	}

	Vector2 GetInput()
	{
		//Scalfo Move randomly
		horizontal_input = Mathf.Round(Random.Range(-1,2));
		vertical_input = Mathf.Round(Random.Range(-1,2));
		//float nes_a = Input.GetAxis ("A");

		//If we're moving horizontally,don't allow any vertical movement!
		if (Mathf.Abs(horizontal_input) > 0.0f)
			vertical_input = 0.0f;
		return new Vector2(horizontal_input, vertical_input);
	}

	IEnumerator GetInputForSeconds(){
		if_go = false;
		yield return new WaitForSeconds(1.0f);
		current_input = GetInput();
		rb.velocity = current_input * movement_speed ;
		if(current_input.x==0 && current_input.y==0){
			correct_position_x = Mathf.Round (tf.position.x);
			correct_position_y = Mathf.Round (tf.position.y);
			tf.position = new Vector3 (correct_position_x, correct_position_y, 0);
		}
		if_go = true;

	}
}

