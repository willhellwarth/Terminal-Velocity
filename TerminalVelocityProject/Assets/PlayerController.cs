using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//static float gravityRadius = 4.4f;
	public GameObject gravityField, ground;
	public float acc = 5f;
	public float topspeed = 15f;
	public float gravity = 7f;
	public float jumpForce = 100f;
	public float groundpoundforce = 500f;
	public bool grounded = false;
	private bool infield = true;
	Vector3 dir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rigidbody2D.AddRelativeForce (Vector2.up * jumpForce);
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			rigidbody2D.AddRelativeForce(Vector2.up * -groundpoundforce);
		}
	
		if (Vector2.Distance (new Vector2 (transform.position.x, transform.position.y), Vector2.zero) < ground.transform.localScale.x / 2f + 0.2f + transform.localScale.y/2f) {
						grounded = true;
				} else {
						grounded = false;
				}

		if (Vector2.Distance (new Vector2 (transform.position.x, transform.position.y), Vector2.zero) < gravityField.transform.localScale.x / 2f) {
						infield = true;
						//transform.LookAt(GameObject.Find("Center").transform, new Vector3(0f,0f,-1f));
						//transform.RotateAround(Vector3.zero, new Vector3(0f,0f,1f), 
			
						Vector3 pos = Vector3.zero;
						dir = transform.position - pos;
						float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
						transform.rotation = Quaternion.AngleAxis (angle - 90f, Vector3.forward);
				} else {
			infield = false;
				}
	}
	void FixedUpdate() {


	
		//if(transform.eulerAngles.z > 270f || transform.eulerAngles.z < 90f)
		if(rigidbody2D.velocity.magnitude < topspeed)
			rigidbody2D.AddRelativeForce(new Vector2 (Input.GetAxis("Horizontal")*acc, 0f ), ForceMode2D.Force);
			//rigidbody2D.AddForce (new Vector2 (Input.GetAxis("Horizontal")*acc, 0f ), ForceMode2D.Force);


		if (true) {
			rigidbody2D.AddForce(new Vector2(dir.x, dir.y).normalized*-gravity);
				}


	}
	void OnDrawGizmos() {


		Gizmos.DrawWireSphere (Vector3.zero, gravityField.transform.localScale.x/2f);
	}

}
