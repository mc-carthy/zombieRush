using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	[SerializeField]
	private Vector3 topPos, bottomPos;
	[SerializeField]
	private float rockSpeed = 3f;

	private void Start () {
		StartCoroutine (Move (bottomPos));
	}

	private IEnumerator Move(Vector3 target) {
		while (Mathf.Abs ((target - transform.localPosition).y) > 0.20f) {
			Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * Time.deltaTime * rockSpeed;

			yield return null;
		}
		yield return new WaitForSeconds (0.5f);

		Vector3 newTarget = target.y == topPos.y ? bottomPos : topPos;

		StartCoroutine (Move (newTarget));
	}
}
