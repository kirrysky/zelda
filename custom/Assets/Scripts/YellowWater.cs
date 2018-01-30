using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowWater : MonoBehaviour {

    public bool is_poison;
    public int is_add;
    public int hearts;
    // Use this for initialization
    void Start()
    {
        is_poison = false;
        is_add = (int)Mathf.Round(Random.Range(-1, 2));
        hearts = (int)Mathf.Round(Random.Range(0, 4));
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;
        Inventory inventory = object_collided_with.GetComponent<Inventory>();

        if (object_collided_with.tag == "Player" && is_poison == false)
        {
            if(is_add > 0)
            {
               //Check to see if our inventory exists before we add a rupee to it.
                if (inventory != null)
                    inventory.AddHearts(hearts);
            }else
            {
                //Check to see if our inventory exists before we add a rupee to it.
                if (inventory != null)
                    inventory.SubtractHearts(hearts);
            }
            is_poison = true;
            is_add = (int)Mathf.Round(Random.Range(-1, 2));
            hearts = (int)Mathf.Round(Random.Range(0, 4));
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
}
