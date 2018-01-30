using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelsMovement : MonoBehaviour
{

    // Inspector Fields
    public float movement_speed = 0.5f;

    Rigidbody rb;
    Transform tf;

    private float correct_position_x;
    private float correct_position_y;
    private float target_position_x;
    private float target_position_y;
    private float before_position_x;
    private float before_position_y;
    private bool if_go = true;

    // Use this for initialization
    void Start()
    {
        //Store a reference to the Rigidbody component on this game object
        //This prevents us from calling GetComponet() every frame, which save performance.
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (if_go == true)
        {
            StartCoroutine(GetInputForSeconds());
        }
    }

    Vector2 GetInput()
    {
        //Scalfo Move randomly
        //horizontal_input = Mathf.Round(Random.Range(-1, 2));
        //vertical_input = Mathf.Round(Random.Range(-1, 2));
        //float nes_a = Input.GetAxis ("A");

        //If we're moving horizontally,don't allow any vertical movement!
        //if (Mathf.Abs(horizontal_input) > 0.0f)
        //     vertical_input = 0.0f;
        
        Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
        Vector2 direction = directions[Random.Range(0, directions.Length)];
        target_position_x = tf.position.x + direction.x;
        target_position_y = tf.position.y + direction.y;
        return direction;
    }

    IEnumerator GetInputForSeconds()
    {
        if_go = false;
        Vector2 current_input = GetInput();
        float distance_x = target_position_x - tf.position.x;
        float distance_y = target_position_y - tf.position.y;
        while (Mathf.Abs(distance_x) <= 1 && Mathf.Abs(distance_y) <= 1)
        {
            rb.velocity = current_input * movement_speed;
            distance_x = target_position_x - tf.position.x;
            distance_y = target_position_y - tf.position.y;
            yield return new WaitForFixedUpdate();
            if (before_position_x == tf.position.x && before_position_y == tf.position.y)
            {
                current_input = GetInput();
            }
            before_position_x = tf.position.x;
            before_position_y = tf.position.y;
        }
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        correct_position_x = Mathf.Round(tf.position.x);
        correct_position_y = Mathf.Round(tf.position.y);
        tf.position = new Vector3(correct_position_x, correct_position_y, 0);
        yield return new WaitForSeconds(2.0f);
        if_go = true;

    }

}
