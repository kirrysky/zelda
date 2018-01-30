using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour {

	public bool getin;
	public GameObject redwater;
	Bridge bridge;
	// Use this for initialization
	void Start()
	{
		getin = false;
		bridge = redwater.GetComponent<Bridge> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		GameObject object_collided_with = coll.gameObject;

		if (object_collided_with.tag == "block" && getin == false)
		{
			
			getin = true;
			bridge.AddGetSet ();
		}

	}
		

}
