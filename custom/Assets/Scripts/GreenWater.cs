using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWater : MonoBehaviour {

    public bool is_poison;
    public int hearts;
	// Use this for initialization
	void Start () {
        is_poison = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;
        Inventory inventory = object_collided_with.GetComponent<Inventory>();

        if (object_collided_with.tag == "Player"&& is_poison==false)
        {
            //Check to see if our inventory exists before we add a rupee to it.
            if (inventory != null)
                inventory.SubtractHearts(hearts);
            is_poison = true;
            StartCoroutine(TurnGreen(object_collided_with));
        }

    }

    void OnTriggerExit(Collider coll)
    {
       is_poison = false;
    }

    IEnumerator TurnGreen(GameObject player)
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.color = new Vector4(0, 1, 0, 1);
        yield return new WaitForSeconds(1.0f);
        sr.color = new Vector4(1, 1, 1, 1);

    }

	public void MianyiPoison () {
		is_poison = true;
	}
}
