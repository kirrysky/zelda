using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAdminDisplay : MonoBehaviour {

	public float disappearRate;
	public GameObject itself;
	private float timeRangeOfDisappear;
	
	// Update is called once per frame
	void Update () {

		//Disappear at 5 seconds
		timeRangeOfDisappear += Time.deltaTime;
		if (timeRangeOfDisappear >= disappearRate)
		{
			Destroy(itself);
		}


	}
}
