using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckInWater : MonoBehaviour {

    public bool stuck;

    private float timeRangeOfDisappear;
    public float disappearRate = 3.0f;

    Collector cl;
    Inventory it;

	// Use this for initialization
	void Start () {
        cl = GetComponent<Collector>();
        it = GetComponent<Inventory>();
        stuck = false;	
	}
	
	// Update is called once per frame
	void Update () {
        if(cl.GetCatchStatus()==false && stuck)
        {
            it.SubtractHearts(6);
        }
        if ((transform.position.x>53 && transform.position.x <55)||
            (transform.position.x > 55 && transform.position.x < 57) ||
            (transform.position.x > 57 && transform.position.x < 59) )
        {
            timeRangeOfDisappear += Time.deltaTime;
        }else
        {
            timeRangeOfDisappear = 0.0f;
        }


        if (timeRangeOfDisappear >= disappearRate)
        {
             stuck = true;
        }


    }

   

}
