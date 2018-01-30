using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{

    public GameObject LockedDoorLeft;
    public GameObject LockedDoorRight;
    public AudioClip opendoor_sound_clip;
    public GameObject leftdoorcollider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OpenDoor(Animator left, Animator right)
    {
        left.SetTrigger("open");
        right.SetTrigger("open");
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.name == "Tile_WALL")
        {
            OpenDoor(LockedDoorLeft.GetComponent<Animator>(), LockedDoorRight.GetComponent<Animator>());
            Physics.IgnoreCollision(GetComponent<Collider>(), collider.GetComponent<Collider>());
            Destroy(leftdoorcollider);
        }

        if (collider.name == "Player")
        {
            
           ArrowKeyMovement akm = collider.gameObject.GetComponent<ArrowKeyMovement>();
           Inventory it = akm.GetComponent<Inventory>();
            if (it.GetKeys() != 0)

            //is_open = true;
            //animleft.SetBool("is_open", true);
            //is_openright = true;
            //animright.SetBool("is_openright", true);

            //is_open2 = true;
            //animleft2.SetBool("is_open2", true);
            //is_openright2 = true;
            //animright2.SetBool("is_openright2", true);
            {
                OpenDoor(LockedDoorLeft.GetComponent<Animator>(), LockedDoorRight.GetComponent<Animator>());
                Physics.IgnoreCollision(GetComponent<Collider>(), collider.GetComponent<Collider>());
                it.SubtractKeys(1);
                AudioSource.PlayClipAtPoint(opendoor_sound_clip, Camera.main.transform.position);

            }

        }
    }
}