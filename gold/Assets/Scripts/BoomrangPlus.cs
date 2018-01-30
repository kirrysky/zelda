using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomrangPlus : MonoBehaviour {

    public GameObject BoomrangPrefab;
    public bool is_shot = true;

    // Update is called once per frame
    void Update()
    {
        if (is_shot)
            StartCoroutine(Shot(BoomrangPrefab));
    }

    IEnumerator Shot(GameObject boomrang)
    {
        is_shot = false;

        GameObject item2 = Instantiate(boomrang, transform.position, Quaternion.identity);
        Rigidbody clone2;
        clone2 = item2.GetComponent<Rigidbody>();
        clone2.velocity = new Vector3(-4.0f, 0.0f, 0.0f);

        yield return new WaitForSeconds(3.0f);
        is_shot = true;

    }
}
