using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowKeyMovement : MonoBehaviour {

	// Inspector Fields
	public float movement_speed = 4;
	public GameObject GameOverPane;
    public GameObject swordPrefab;
    public GameObject bowPrefab;
    public GameObject boomrangPrefab;
    public GameObject bombPrefab;
	public GameObject sword;
    public int weapon_nums;
	public bool is_catched;
	public float disappearRate;
	private float timeRangeOfDisappear;

    Rigidbody rb;
	Transform tf;
	Inventory it;

    Animator m_Animator;
    string m_ClipName;
    AnimatorClipInfo[] m_CurrentClipInfo;

    private float correct_position_x;
	private float correct_position_y;

    Vector2 inputVelocity = Vector2.zero;
    public Vector2 knockbackVelocity = Vector2.zero;

	// Use this for initialization
	void Start () {
		//Store a reference to the Rigidbody component on this game object
		//This prevents us from calling GetComponet() every frame, which save performance.
		Screen.SetResolution(512,480,true);
		rb = GetComponent<Rigidbody>();
		tf = GetComponent<Transform>();
		it = GetComponent<Inventory>();
        weapon_nums = 0;
		is_catched = false;
    }

	// Update is called once per frame
	void Update () {
		if (is_catched == false) {
			//Move current player
			Vector2 current_input = GetInput ();
			inputVelocity = current_input * movement_speed;

			rb.velocity = inputVelocity + knockbackVelocity;

			//make every movement half tile
			if (current_input.x == 0 && current_input.y == 0) {
				correct_position_x = Mathf.Round (tf.position.x * 2);
				correct_position_y = Mathf.Round (tf.position.y * 2);
				tf.position = new Vector3 (correct_position_x / 2, correct_position_y / 2, 0);
			}
		}
			
			
		//Game Over
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

        //use sword
        if (Input.GetKeyDown(KeyCode.X)) { 
			var sword = GameObject.Find ("/Sword(Clone)");
            if (sword == null)
            {
                Shot(swordPrefab);
            }
        }
		//draw back sword if go away
		if (rb.velocity != new Vector3(0.0f,0.0f,0.0f)) {
			sword.SetActive (false);
		}

        



    }

    public Vector2 GetInput()
	{
		//The following Input.GetAxis calls make use of the Unity InputManager.
		//The InputManager allows us to standardize controls without hard-coding specific key or buttons.
		//For instance, the code below would work with a keyboard, OR a controller, without changes!

		//Grab the current value of the right-left arrow keys
		float horizontal_input = Input.GetAxisRaw("Horizontal");
		//Grab the current value of the up-down arrow keys
		float vertical_input = Input.GetAxisRaw("Vertical");

		//float nes_a = Input.GetAxis ("A");

		//If we're moving horizontally,don't allow any vertical movement!
		if (Mathf.Abs(horizontal_input) > 0.0f)
			vertical_input = 0.0f;
		return new Vector2(horizontal_input, vertical_input);
	}

    public string GetAnimationName()
    {
        //Get them_Animator, which you attach to the GameObject you intend to animate.
        m_Animator = GetComponent<Animator>();
        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
        //Access the Animation clip name
        m_ClipName = m_CurrentClipInfo[0].clip.name;
        return m_ClipName;
    }

    public void Shot(GameObject Prefab)
    {
        GameObject item = Instantiate(Prefab, tf.position, Quaternion.identity);
        Rigidbody clone;
        clone = item.GetComponent<Rigidbody>();
        if (GetAnimationName() == "run_up" || GetAnimationName() == "sword_up" || GetAnimationName() =="bow_up")
        {
            clone.velocity = new Vector3(0.0f, 6.0f, 0.0f);
            item.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (GetAnimationName() == "run_down" || GetAnimationName() == "sword_down" || GetAnimationName() == "bow_down")
        {
            clone.velocity = new Vector3(0.0f, -6.0f, 0.0f);
        }
        if (GetAnimationName() == "run_left" || GetAnimationName() == "sword_left" || GetAnimationName() == "bow_left")
        {
            clone.velocity = new Vector3(-6.0f, 0.0f, 0.0f);
            item.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (GetAnimationName() == "run_right" || GetAnimationName() == "sword_right" || GetAnimationName() == "bow_right")
        {
            clone.velocity = new Vector3(6.0f, 0.0f, 0.0f);
            item.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

	IEnumerator Draw(){
		sword.SetActive (true);
		if (GetAnimationName() == "run_up" || GetAnimationName() == "sword_up" || GetAnimationName() =="bow_up")
		{
			sword.transform.position = tf.position+Vector3.up*0.5f+Vector3.left*0.1f;
			sword.transform.rotation = Quaternion.Euler(0, 0, 180);
		}
		if (GetAnimationName() == "run_down" || GetAnimationName() == "sword_down" || GetAnimationName() == "bow_down")
		{
			sword.transform.position = tf.position-Vector3.up*0.5f;
			sword.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		if (GetAnimationName() == "run_left" || GetAnimationName() == "sword_left" || GetAnimationName() == "bow_left")
		{
			sword.transform.position = tf.position+Vector3.left*0.5f+Vector3.down*0.1f;
			sword.transform.rotation = Quaternion.Euler(0, 0, -90);
		}
		if (GetAnimationName() == "run_right" || GetAnimationName() == "sword_right" || GetAnimationName() == "bow_right")
		{
			sword.transform.position = tf.position-Vector3.left*0.5f+Vector3.down*0.1f;
			sword.transform.rotation = Quaternion.Euler(0, 0, 90);
		}
		yield return new WaitForSeconds (2.0f);
		sword.SetActive (false);
	}

	public void Catched(){
		if (is_catched == false) {
			is_catched = true;
		}
	}
}
