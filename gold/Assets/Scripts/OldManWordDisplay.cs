using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldManWordDisplay : MonoBehaviour {

	public Text text_component;
	string words;
	public int n;
	int nmax;

	public float disappearRate;
	private float timeRangeOfDisappear;

	// Use this for initialization
	void Start () {
		text_component = GetComponent<Text> ();
		words = "EASTMOST PENNINSULA \n IS THE SECRET.";
		n = 0;
		nmax = words.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (n == 0) {
			text_component.text = "";
		}
		//Disappear at 5 seconds
		timeRangeOfDisappear += Time.deltaTime;
		if (timeRangeOfDisappear >= disappearRate)
		{
			if (text_component != null && n < nmax) {
				if (n ==0) {
					text_component.text = "" + words [n];
				} else {
					text_component.text += words [n];
				}
				n += 1;
			}
			timeRangeOfDisappear = 0.0f;
		}
	}


}
