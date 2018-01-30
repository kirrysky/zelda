using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAnotherRoom : MonoBehaviour {
    GameObject player;
    Camera main_camera;
    public float camera_speed = 10f;

    private bool isLerp = false;
    private Vector2 input;
    private Vector3 source_camera_position;
    private Vector3 target_camera_position;
    private float startTime;
    private float journeyLength;

    private void Start()
    {
        main_camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(isLerp)
        {
            PositionChanging();
            if (main_camera.transform.position.Equals(target_camera_position))
            {
                isLerp = false;
                player.transform.position = new Vector3(player.transform.position.x + 3.5f * input.x, player.transform.position.y + 3.5f * input.y);
                player.SetActive(true);
            }
        }
    }

    private void PositionChanging()
    {
        // move camera slowly
        float distCovered = (Time.time - startTime) * camera_speed;
        float fracJourney = distCovered / journeyLength;
        main_camera.transform.position = Vector3.Lerp(source_camera_position, target_camera_position, fracJourney);
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player") {
            player = other.gameObject;
            ArrowKeyMovement akm = player.GetComponent<ArrowKeyMovement>();
            input = other.GetComponent<ArrowKeyMovement>().GetInput();
            player.SetActive(false);
            // target camera position
            source_camera_position = main_camera.transform.position;
            target_camera_position = source_camera_position;
            target_camera_position.x = source_camera_position.x + 16f * input.x;
            target_camera_position.y = source_camera_position.y + 11f * input.y;
            startTime = Time.time;
            journeyLength = Vector3.Distance(source_camera_position, target_camera_position);
            isLerp = true;
        }
	}
		




}
