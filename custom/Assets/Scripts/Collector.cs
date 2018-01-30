using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{

    public AudioClip rupee_collection_sound_clip;
    public AudioClip meet_scalfo_sound_clip;
    public AudioClip heart_collection_sound_clip;
    public bool is_catched = true;

    public bool meet_scalfo = false;
    public float movement_speed = 100;

    Camera main_camera;
    SpriteRenderer sr;
    Rigidbody rb;
    Inventory inventory;
    ArrowKeyMovement movement;

    void Start()
    {
        // Try to grab a reference to the inventory component on this gameobject
        inventory = GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning("WARNING: Gameobject with a collector has no inventory to store things in!");
        }
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        movement = this.GetComponent<ArrowKeyMovement>();
        main_camera = Camera.main;
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        //collect rupee
        if (object_collided_with.tag == "rupee")
        {
            //Check to see if our inventory exists before we add a rupee to it.
            if (inventory != null)
                inventory.AddRupees(1);
            Destroy(object_collided_with);

            //Play sound effect
            //What does audio files matter with camera's transform's position?
            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }


        //collect heart
        if (object_collided_with.tag == "heart")
        {
            //Check to see if our inventory exists before we add a rupee to it.
            if (inventory != null)
                inventory.AddHearts(2);
            Destroy(object_collided_with);

            //Play sound effect
            //What does audio files matter with camera's transform's position?
            AudioSource.PlayClipAtPoint(heart_collection_sound_clip, Camera.main.transform.position);
        }

        //collect keys
        if (object_collided_with.tag == "key")
        {
            //Check to see if our inventory exists before we add a rupee to it.
            if (inventory != null)
                inventory.AddKeys(1);
            Destroy(object_collided_with);

            //Play sound effect
            //What does audio files matter with camera's transform's position?
            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "fireball" && meet_scalfo == false)
        {
            //Check to see if our inventory exists before we add a rupee to it.
            if (inventory != null)
                inventory.SubtractHearts(1);
            AudioSource.PlayClipAtPoint(meet_scalfo_sound_clip, Camera.main.transform.position);
            Destroy(object_collided_with);
            StartCoroutine(TurnRed());
        }

        if (object_collided_with.tag == "Wallmaster")
        {
            //Check to see if our inventory exists before we add a rupee to it.
            StartCoroutine(Catched(object_collided_with));
            StartCoroutine(Catched2(object_collided_with));
        }




    }

    //meet scalfo
    void OnCollisionEnter(Collision coll)
    {
        GameObject object_collided_with = coll.gameObject;
        var sword = GameObject.Find("/Sword");
        if ((object_collided_with.GetComponent<Collider>().tag == "stalfo" ||
            object_collided_with.GetComponent<Collider>().tag == "Aquamentus" ||
            object_collided_with.GetComponent<Collider>().tag == "BladeTrap" ||
            object_collided_with.GetComponent<Collider>().tag == "fireball" ||
            object_collided_with.GetComponent<Collider>().tag == "gel" ||
            object_collided_with.GetComponent<Collider>().tag == "Keese" ||
            object_collided_with.GetComponent<Collider>().tag == "Goriya") && sword == null)
        {
            //Check to see if our inventory exists before we add a rupee to it.
            if (meet_scalfo == false)
            {
                meet_scalfo = true;
                if (inventory != null)
                    inventory.SubtractHearts(1);
                //Play sound effect
                //What does audio files matter with camera's transform's position?
                AudioSource.PlayClipAtPoint(meet_scalfo_sound_clip, Camera.main.transform.position);

                //bouncing back
                StartCoroutine(Knockback((this.transform.position - coll.transform.position).normalized));
                StartCoroutine(SetMeetScalfo());
                StartCoroutine(TurnRed());

            }

        }
    }


    IEnumerator Knockback(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            direction = Vector2.right * Mathf.Sign(direction.x);
        else
            direction = Vector2.up * Mathf.Sign(direction.y);
        movement.knockbackVelocity = direction * 3;
        yield return new WaitForSeconds(1);
        movement.knockbackVelocity = Vector2.zero;

    }

    IEnumerator TurnRed()
    {

        sr.color = new Vector4(1, 0, 0, 1);
        yield return new WaitForSeconds(1.0f);
        sr.color = new Vector4(1, 1, 1, 1);

    }

    IEnumerator Catched(GameObject wallmaster)
    {

        while (wallmaster.transform != null && is_catched == true)
        {
            transform.position = wallmaster.transform.position;
            yield return null;
        }

    }

    IEnumerator Catched2(GameObject wallmaster)
    {

        yield return new WaitForSeconds(3.0f);
        
    }

    IEnumerator SetMeetScalfo()
    {

        yield return new WaitForSeconds(3.0f);
        meet_scalfo = false;
    }

    void Update()
    {
        //Invincibility/ Infinite Keys/ Bomb/ Rupees Cheat
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            meet_scalfo = true;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (is_catched == true)
            {
                is_catched = false;
            }
        }

		if (Input.GetKeyDown(KeyCode.C))
		{
			if (is_catched == false)
			{
				is_catched = true;
			}
		}
			

    }

	public bool GetCatchStatus(){
		return is_catched;
	}

}
