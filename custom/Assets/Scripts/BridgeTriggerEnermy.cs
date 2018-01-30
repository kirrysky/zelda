using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerEnermy : MonoBehaviour {

	public GameObject redwater;

	Bridge bridge;
	LossHeal lh;

	// Use this for initialization
	void Start () {
		lh = GetComponent<LossHeal>();
		bridge = redwater.GetComponent<Bridge> ();
	}

	// Update is called once per frame
	void Update () {
		if (lh.enermy_heal == 0)
		{
			bridge.AddGetSet ();
		}

	}
}
