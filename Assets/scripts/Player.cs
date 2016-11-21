using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private Rigidbody rb;

	private bool jumping = false;
	[SerializeField]
	private float jumpForce;

	private void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	private void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Jump ();
		}
	}

	private void FixedUpdate () {
		if (jumping) {
			rb.velocity = Vector3.zero;
			rb.AddForce (new Vector3 (0, jumpForce, 0), ForceMode.Impulse);
			jumping = false;
		}
	}

	private void Jump () {
		anim.Play ("Jump");
		rb.useGravity = true;
		jumping = true;
	}
}
