using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour {

	public Inventory inventory;
	Text text_component;
	private float HeartNum;

	// Use this for initialization
	void Start () {

		text_component = GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {
		if (inventory != null && text_component != null) {
			HeartNum = inventory.GetHearts () / 2.0f;
			text_component.text = "Hearts:" + HeartNum.ToString ();
		}

	}
}
