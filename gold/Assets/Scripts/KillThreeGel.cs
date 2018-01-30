using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThreeGel : MonoBehaviour {

	public GameObject gel1;
	public GameObject gel2;
	public GameObject gel3;
	public GameObject itself;
	LossHeal lh1;
	LossHeal lh2;
	LossHeal lh3;

	void Start(){
		lh1 = gel1.GetComponent<LossHeal> ();
		lh2 = gel2.GetComponent<LossHeal> ();
		lh3 = gel3.GetComponent<LossHeal> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lh1.enermy_heal == 0 && lh2.enermy_heal == 0 && lh3.enermy_heal == 0) {
			itself.SetActive (false);
		} 
	}
}
