using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour {

	Animator animator;
    bool useWeapon=false;

    string m_ClipName;
    AnimatorClipInfo[] m_CurrentClipInfo;

    // Use this for initialization
    void Start () {
		animator = GetComponent<Animator> ();
	}

    // Update is called once per frame
    void Update()
    {

        //Run
        animator.SetFloat("horizontal_input", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("vertical_input", Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {

            animator.speed = 0.0f;
        }
        else
        {

            animator.speed = 1.0f;
        }

        if (useWeapon == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(UseWeapon("use_sword"));
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(UseWeapon("use_bow"));
            }

        }
    }

    public string GetAnimationName()
    {
        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = this.animator.GetCurrentAnimatorClipInfo(0);
        //Access the Animation clip name
        m_ClipName = m_CurrentClipInfo[0].clip.name;
        return m_ClipName;
    }

    public int GetDirection()
    {
        int direction = 0;
        if (GetAnimationName() == "run_up" || GetAnimationName() == "sword_up" || GetAnimationName() == "bow_up")
        {
            direction = 1;
        }
        if (GetAnimationName() == "run_down" || GetAnimationName() == "sword_down" || GetAnimationName() == "bow_down")
        {
            direction = 3;
        }
        if (GetAnimationName() == "run_left" || GetAnimationName() == "sword_left" || GetAnimationName() == "bow_left")
        {
            direction = 4;
        }
        if (GetAnimationName() == "run_right" || GetAnimationName() == "sword_right" || GetAnimationName() == "bow_right")
        {
            direction = 2;
        }
        return direction;
    }

    IEnumerator UseWeapon(string weapon)
    {
        useWeapon = true;
        animator.SetBool(weapon, true);
        animator.SetInteger("direction", GetDirection());

        yield return new WaitForSeconds(0.5f);

        useWeapon = false;
        animator.SetBool(weapon, false);
        animator.SetInteger("direction", 0);
    }
}
