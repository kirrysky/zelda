using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMasterOpen : MonoBehaviour {

    public GameObject WallMasterPrefab;
    
    public Vector3 first_step;
    public Vector3 second_step;
	public Vector3 destination;
    Rigidbody rb;
    Transform tf;
    WallmasterMovement wm;
 

    public bool initallawallmaster=true;

    private void OnTriggerStay(Collider other)
    {
        GameObject player = other.gameObject;
        if (player.tag == "Player" && initallawallmaster==true)
        {
            StartCoroutine(InitallWM(player));
        }

    }

    IEnumerator InitallWM(GameObject player)
    {
        initallawallmaster = false;
        GameObject wallmaster = Instantiate(WallMasterPrefab, transform.position, Quaternion.identity);
        tf = wallmaster.GetComponent<Transform>();
        rb = wallmaster.GetComponent<Rigidbody>();
        wm = wallmaster.GetComponent<WallmasterMovement>();
		wm.destination = destination;
        wm.first_step = first_step;
        wm.second_step = second_step;
		tf.position = destination - 1 * first_step - 4 * second_step;
        yield return new WaitForSeconds(3.0f);
        initallawallmaster = true;
    }
}
