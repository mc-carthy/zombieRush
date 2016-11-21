using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private Rigidbody rb;
	private AudioSource source;
	[SerializeField]
	private AudioClip sfxJump;

	private bool jumping = false;
	private float jumpForce = 15f;

	private void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		source = GetComponent<AudioSource> ();
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
		source.PlayOneShot (sfxJump);
		rb.useGravity = true;
		jumping = true;
	}
}
