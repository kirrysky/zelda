using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTrigger : MonoBehaviour {
	public GameObject OldManWord;
	public GameObject Player;
	public bool getin;
	public bool getout;

	OldManWordDisplay omd;

	void Start(){
		bool getin = false;
		bool getout = false;
		omd = OldManWord.GetComponent<OldManWordDisplay>();
		
	}

	private void OnTriggerEnter(Collider other)
	{
		GameObject object_collided_with = other.gameObject;	
		if (object_collided_with.tag == "Player") {
			if (getin == false && getout == false) {
				omd.n = 0;
				OldManWord.SetActive (true);
			}
			if (getin == true && getout == true) {
				OldManWord.SetActive (false);
			}

			Rigidbody rb = object_collided_with.GetComponent<Rigidbody> ();
			if (rb.velocity.x < 0) {
				getin = true;
			}
			if (rb.velocity.x > 0) {
				getout = false;
			}	
		}

	}

	private void OnTriggerExit(Collider other){
		GameObject object_collided_with = other.gameObject;	
		if (object_collided_with.tag == "Player") {
			Rigidbody rb = object_collided_with.GetComponent<Rigidbody> ();
			if (rb.velocity.x < 0) {
				getout = true;
			}
			if (rb.velocity.x > 0) {
				getin = false;
			}
		
			if (getin == false && getout == false) {
				OldManWord.SetActive (false);
			}
		}
	}
}
