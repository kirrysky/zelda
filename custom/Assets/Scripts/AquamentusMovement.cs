using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquamentusMovement : MonoBehaviour {

    public float movement_speed=0.5f;

    Vector2 current_input;
    private bool is_move = true;

    Rigidbody rb;
    Transform tf;
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        current_input = GetInput();
    }


    //Movement Range 76.5 - 73.5
    Vector2 GetInput()
    {
        Vector2[] directions = {Vector2.left, Vector2.right };
        Vector2 direction = directions[Random.Range(0, directions.Length)];
        return direction;
    }

    // Update is called once per frame
    void Update () {
        if (is_move == true) {
            StartCoroutine(GetInputForSeconds());
        }         
    }

    IEnumerator GetInputForSeconds()
    {
        is_move = false;
        yield return new WaitForSeconds(1.0f);
        current_input = GetInput();
        if (tf.position.x - 73.5f < -0.1)
        {
            rb.velocity = Vector2.right * movement_speed;

        }else
        {
            if (tf.position.x - 76.5f > 0.1)
            {
                rb.velocity = Vector2.left * movement_speed;
            }else
            {
                rb.velocity = current_input * movement_speed;
            }
        }

        is_move = true;
    }
}
