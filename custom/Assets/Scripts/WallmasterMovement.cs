using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallmasterMovement : MonoBehaviour {

    public GameObject itself;
    public Vector3 first_step;
    public Vector3 second_step;
    public float movement_speed;
    public float disappearRate = 15f;

    Rigidbody rb;
    Transform tf;
    int steps;
    public Vector3 destination;

    private float correct_position_x;
    private float correct_position_y;
    private float timeRangeOfDisappear;


    // Use this for initialization
    void Start () {
        steps = 0;
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (steps == 0){
            rb.velocity = first_step * movement_speed;
            if ((Mathf.Abs(tf.position.x-destination.x)<0.1) || (Mathf.Abs(tf.position.y - destination.y)<0.1))
            {
                steps = 1;
                correct_position_x = Mathf.Round(tf.position.x);
                correct_position_y = Mathf.Round(tf.position.y);
                tf.position = new Vector3(correct_position_x, correct_position_y, 0);
            }
        }
        if (steps == 1)
        {
            rb.velocity = second_step * movement_speed;
            if ((Mathf.Abs(tf.position.x - destination.x)) < 0.1 && (Mathf.Abs(tf.position.y - destination.y) < 0.1))
            {
                steps = 2;
                correct_position_x = Mathf.Round(tf.position.x);
                correct_position_y = Mathf.Round(tf.position.y);
                tf.position = new Vector3(correct_position_x, correct_position_y, 0);
            }
        }
        if (steps == 2)
        {
            rb.velocity = -first_step * movement_speed;
        }

        timeRangeOfDisappear += Time.deltaTime;
        if (timeRangeOfDisappear >= disappearRate)
        {
            Destroy(itself);
        }

    }


}
