using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushbox : MonoBehaviour {

    public bool pushtoopen = false;


    private void OnCollisionStay(Collision cl)
    {

	if (cl.rigidbody != null&&pushtoopen==true)
        {
            cl.rigidbody.WakeUp();

        }
    }

	public void changePushtoopen(){
		pushtoopen = true;
	}


    }