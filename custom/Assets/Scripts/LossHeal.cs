using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossHeal : MonoBehaviour {

	public int enermy_heal;
	public GameObject enermy;
	SpriteRenderer sr;


	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}

	void Update(){
		if (enermy_heal == 0) {
			//disappear
			enermy.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider coll){
		GameObject object_collided_with = coll.gameObject;

		//kill by sword
		if (object_collided_with.tag == "sword" ) {
			object_collided_with.SetActive (false);
			StartCoroutine (TurnRed ());


		}
		if (object_collided_with.tag == "arrow")
        {
            Destroy(object_collided_with);
            StartCoroutine(TurnRed());
        }

		if (object_collided_with.tag == "boomerang" && enermy.tag == "Keese")
		{
			Destroy(object_collided_with);
			StartCoroutine(TurnRed());
		}
    }
			
	void OnCollisionEnter(Collision coll){
		GameObject object_collided_with = coll.gameObject;

		//kill by sword
		if (object_collided_with.tag == "sword" ||
			object_collided_with.tag == "boomerang" ||
			object_collided_with.tag == "arrow" ) {
			Destroy (object_collided_with);
			StartCoroutine (TurnRed ());


		}
			
	}

	IEnumerator TurnRed(){

		sr.color =new Vector4 (1, 0, 0, 1);
		enermy_heal -= 1;
		yield return new WaitForSeconds(1.0f);
		sr.color =new Vector4 (1, 1, 1, 1);

	}

}
