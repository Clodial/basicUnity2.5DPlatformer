using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	public bool grounded;
	public Vector3 jump;
	public float speed = 0.5f; 
	public float jumpForce = 4.0f;
	public Rigidbody shadow;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 4.0f, 0.0f);
	}
	
	void OnCollisionEnter(Collision other)
	{
		grounded = true;	
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			rb.AddForce(jump * jumpForce, ForceMode.VelocityChange);
			grounded = false;
		}
	}

	void FixedUpdate()
	{
		float leftright = Input.GetAxisRaw("Horizontal");
		float updown = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3(leftright, 0.0f, updown);
		rb.MovePosition(rb.position + movement * Time.deltaTime * 5);
		shadow.MovePosition(rb.position + movement * Time.deltaTime * 5);

	}
}
