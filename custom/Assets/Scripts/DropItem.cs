using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
    public GameObject item;

    LossHeal lh;
    
	// Use this for initialization
	void Start () {
        lh = GetComponent<LossHeal>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lh.enermy_heal == 0)
        {
            GameObject item_copy = Instantiate(item, transform.position, Quaternion.identity);
        }
		
	}
}
