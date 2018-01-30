using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mianyi : MonoBehaviour {

	public GameObject water_green;
	public GameObject player;
	GreenWater gw;
	Collector cl;

	// Use this for initialization
	void Start () {
		gw = water_green.GetComponent<GreenWater> ();
		cl = player.GetComponent<Collector> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (cl.GetCatchStatus() == true) {
			gw.MianyiPoison ();
		}

	}
}
