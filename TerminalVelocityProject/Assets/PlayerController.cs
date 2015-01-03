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
	private bool infield, jumping;
	Vector3 dir;
	// Use this for initialization
	void Start () {
		GetComponent<TrailRenderer> ().startWidth = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 jumpdir = (transform.position - new Vector3 (0f, 0f, transform.position.z)).normalized;
		Vector2 jumpdir2 = new Vector2 (jumpdir.x, jumpdir.y);
		//new Vector2(transform.up.x, transform.up.y)

		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			jumping = true;
			rigidbody2D.AddForce (jumpdir2 * jumpForce);
		}
		if (Input.GetKeyUp (KeyCode.Space) && jumping) {
			jumping = false;
				}
		else if (Input.GetKey (KeyCode.Space) &! jumping &! grounded) {
			rigidbody2D.AddForce(jumpdir2 * -groundpoundforce);
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
		//if(rigidbody2D.velocity.magnitude < topspeed)
		if(rigidbody2D.GetRelativePointVelocity(new Vector2(transform.position.x, transform.position.y)).x < topspeed && Input.GetAxis("Horizontal") > 0)
			rigidbody2D.AddRelativeForce(new Vector2 (Input.GetAxis("Horizontal")*acc, 0f ), ForceMode2D.Force);

		if(rigidbody2D.GetRelativePointVelocity(new Vector2(transform.position.x, transform.position.y)).x > -topspeed && Input.GetAxis("Horizontal") < 0)
			rigidbody2D.AddRelativeForce(new Vector2 (Input.GetAxis("Horizontal")*acc, 0f ), ForceMode2D.Force);
			//rigidbody2D.AddForce (new Vector2 (Input.GetAxis("Horizontal")*acc, 0f ), ForceMode2D.Force);


		if (true) {
			rigidbody2D.AddForce(new Vector2(transform.up.x, transform.up.y)*-gravity);
				}


	}
	void OnDrawGizmos() {


		Gizmos.DrawWireSphere (Vector3.zero, gravityField.transform.localScale.x/2f);
	}

}
