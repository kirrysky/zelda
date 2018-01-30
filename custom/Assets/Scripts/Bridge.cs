using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

	public int getset;
	public int max;
	public GameObject road;
	public GameObject redwater;

	void Start(){
		int getset = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (getset == max) {
			road.SetActive (true);
			redwater.SetActive (false);
		}
	}

	public void AddGetSet(){
		getset += 1;
	}
}
