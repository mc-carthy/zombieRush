using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private Rigidbody rb;
	private AudioSource source;
	[SerializeField]
	private AudioClip sfxJump;
	[SerializeField]
	private AudioClip sfxDeath;

	private bool jumping = false;
	private float jumpForce = 15f;

	private void Awake () {
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}

	private void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		source = GetComponent<AudioSource> ();
	}

	private void Update () {
		if (!GameManager.instance.IsGameOver && GameManager.instance.IsGameStarted) {
			if (!GameManager.instance.IsPlayerActive) {
				GameManager.instance.PlayerStartedGame ();
			}
			if (Input.GetMouseButtonDown (0)) {
				Jump ();
			}
		}
	}

	private void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("obstacle")) {
			Die ();
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

	private void Die () {
		source.PlayOneShot (sfxDeath);
		rb.AddForce (new Vector3 (-5f, 2f), ForceMode.Impulse);
		rb.detectCollisions = false;
		GameManager.instance.PlayerCollided ();
	}
}
