using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrapOpen : MonoBehaviour {

    public GameObject bt1;
    public GameObject bt2;

    BladeTrapMovement btm1;
    BladeTrapMovement btm2;
    public Vector3 direction1;
    public Vector3 direction2;

    void Start()
    {
        btm1 = bt1.GetComponent<BladeTrapMovement>();
        btm2 = bt2.GetComponent<BladeTrapMovement>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (btm1.is_touched == false)
        {
            btm1.is_touched = true;
            btm1.direction = direction1;
        }
        if (btm2.is_touched == false)
        {
            btm2.is_touched = true;
            btm2.direction = direction2;
        }
    }

}
