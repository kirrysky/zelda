using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomrangMovement : MonoBehaviour
{

    public float disappearRate = 3.0f;
    public float backRate = 1.5f;
    public GameObject itself;
    public GameObject swordanim;

    Rigidbody rb;

    private float timeRangeOfDisappear;
    private bool forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Disappear at 5 seconds
        timeRangeOfDisappear += Time.deltaTime;
        if (timeRangeOfDisappear >= backRate && forward == true)
        {
            rb.velocity = -rb.velocity;
            transform.Rotate(0, 0, 180);
            forward = false;
        }
        if (timeRangeOfDisappear >= disappearRate)
        {
            Destroy(itself);
        }


    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;
        if (object_collided_with.GetComponent<Collider>().tag == "Keese")
        {
            DisplaySwordAnim(swordanim);
            Destroy(itself);
        }
    }
    void DisplaySwordAnim(GameObject Prefab)
    {
        GameObject item = Instantiate(Prefab, transform.position, Quaternion.identity);
    }
}