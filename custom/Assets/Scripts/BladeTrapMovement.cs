using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrapMovement : MonoBehaviour {

    public bool is_touched;
    public bool forward;
    public Vector3 direction;
    public float movement_speed_forward = 4.0f;
    public float movement_speed_backward = 2.0f;

    Rigidbody rb;
    Transform tf;

    Vector3 before;
    void Start() {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        before = tf.position;
        forward = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (is_touched)
        {
            if (forward)
            {
                rb.velocity = direction * movement_speed_forward;
                if ((Mathf.Abs(tf.position.x - (before.x + 5.0f * direction.x)) < 0.1) && (Mathf.Abs(tf.position.y - (before.y + 2.5f * direction.y)) < 0.1))
                {
                    forward = false;
                }
            }
            else
            {
                rb.velocity = direction * -movement_speed_backward;
                if ((Mathf.Abs(tf.position.x - before.x) < 0.1) && (Mathf.Abs(tf.position.y - before.y) < 0.1)){
                    forward = true;
                    is_touched = false;
                }

            }
        }
    }
}
