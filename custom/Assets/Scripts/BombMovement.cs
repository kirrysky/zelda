using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{

    public float disappearRate = 3.0f;
    public GameObject itself;
    public bool boooooom;
    public bool smoke;
    public GameObject bombanim;

    Rigidbody rb;

    private float timeRangeOfDisappear;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boooooom = false;
        smoke = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Disappear at 5 seconds
        timeRangeOfDisappear += Time.deltaTime;

        if (timeRangeOfDisappear >= disappearRate)
        {
            boooooom = true;
        }
        if (timeRangeOfDisappear >= (disappearRate + 1.0f))
        {
            if (smoke == false)
            {
                DisplayBombAnim(bombanim);
                smoke = true;
            }
            Destroy(itself);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        GameObject object_collided_with = other.gameObject;
        if (boooooom == true)
        {
            
            //need to change to enermy
            if (object_collided_with.tag == "stalfo" ||
            object_collided_with.tag == "gel" ||
            object_collided_with.tag == "Goriya" ||
            object_collided_with.tag == "keese" ||
            object_collided_with.tag == "Wallmaster"||
            object_collided_with.tag == "Aquamentus")
            {
                if (smoke == false)
                {
                    DisplayBombAnim(bombanim);
                    smoke = true;
                }
                StartCoroutine(TurnRed(object_collided_with));          
                
            }
        }
    }

    IEnumerator TurnRed(GameObject other)
    {
        SpriteRenderer sr;
        sr = other.GetComponent<SpriteRenderer>();
        sr.color = new Vector4(1, 0, 0, 1);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Vector4(1, 1, 1, 1);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Vector4(1, 0, 0, 1);
        yield return new WaitForSeconds(0.3f);
        Destroy(other);
        Destroy(itself);

    }

    void DisplayBombAnim(GameObject Prefab)
    {
        GameObject item = Instantiate(Prefab, transform.position, Quaternion.identity);
    }
}
