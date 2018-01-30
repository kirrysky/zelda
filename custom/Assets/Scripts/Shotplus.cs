using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotplus : MonoBehaviour {

    public GameObject fireballPrefab;
    public bool is_shot=true;

    // Update is called once per frame
    void Update () {
        if (is_shot)
            StartCoroutine(Shot(fireballPrefab));		
	}

    IEnumerator Shot(GameObject fireball)
    {
        is_shot = false;
		GameObject item1 = Instantiate(fireball, new Vector3(transform.position.x,transform.position.y,0f), Quaternion.identity);
        Rigidbody clone1;
        clone1 = item1.GetComponent<Rigidbody>();
        clone1.velocity = new Vector3(-3.4f, -2.0f, 0.0f);

		GameObject item2 = Instantiate(fireball, new Vector3(transform.position.x,transform.position.y,0f), Quaternion.identity);
        Rigidbody clone2;
        clone2 = item2.GetComponent<Rigidbody>();
        clone2.velocity = new Vector3(-4.0f, 0.0f, 0.0f);

		GameObject item3 = Instantiate(fireball, new Vector3(transform.position.x,transform.position.y,0f), Quaternion.identity);
        Rigidbody clone3;
        clone3 = item3.GetComponent<Rigidbody>();
        clone3.velocity = new Vector3(-3.4f, 2.0f, 0.0f);

        yield return new WaitForSeconds(1.0f);
        is_shot = true;

    }
}
