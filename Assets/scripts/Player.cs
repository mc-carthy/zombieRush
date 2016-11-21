using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;

	private void Start () {
		anim = GetComponent<Animator> ();
	}

	private void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Jump ();
		}
	}

	private void Jump () {
		anim.Play ("Jump");
	}
}
