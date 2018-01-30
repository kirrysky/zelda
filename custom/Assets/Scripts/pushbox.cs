using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushbox : MonoBehaviour {

        private bool pushtoopen = false;

        private void OnCollisionStay(Collision cl)
        {

            if (cl.rigidbody != null)
            {
                cl.rigidbody.WakeUp();

            }

            pushtoopen = true;
        }
    }