using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRoomTrigger : MonoBehaviour {

    public Vector3 destination;
    public Vector3 camera_destination;
    Camera main_camera;

    void Start()
    {
        main_camera = Camera.main;
    }


    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        //kill by sword
        if (object_collided_with.tag == "Player")
        {
            object_collided_with.transform.position = destination;
            main_camera.transform.position = camera_destination;

        }

    }

}
