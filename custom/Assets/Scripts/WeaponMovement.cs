using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour {

    public float disappearRate = 3f;
    public GameObject itself;
	public GameObject swordanim;

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


	void OnCollisionEnter(Collision coll){
		GameObject object_collided_with = coll.gameObject;
		if (object_collided_with.GetComponent<Collider>().tag != "Player") {
			DisplaySwordAnim (swordanim);
			Destroy (itself);
		}
	}

	void DisplaySwordAnim(GameObject Prefab){
		GameObject item = Instantiate(Prefab, transform.position, Quaternion.identity);
	}

}
