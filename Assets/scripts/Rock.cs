using UnityEngine;
using System.Collections;

public class Rock : Platform {

	[SerializeField]
	private Vector3 topPos, bottomPos;
	[SerializeField]
	private float speedY = 3f;


	private void Start () {
		StartCoroutine (Move (bottomPos));
	}

	protected override void Update () {
		if (GameManager.instance.IsPlayerActive) {
			base.Update ();
		}
	}

	private IEnumerator Move(Vector3 target) {
		while (Mathf.Abs ((target - transform.localPosition).y) > 0.20f) {
			Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * Time.deltaTime * speedY;

			yield return null;
		}
		yield return new WaitForSeconds (0.5f);

		Vector3 newTarget = target.y == topPos.y ? bottomPos : topPos;

		StartCoroutine (Move (newTarget));
	}
}
