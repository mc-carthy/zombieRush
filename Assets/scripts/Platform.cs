using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	[SerializeField]
	private float platformSpeed = 2;
	private float resetPosX = -30f;
	private float spawnPosX = 31f;

	private void Update () {
		transform.Translate(Vector3.left * platformSpeed * Time.deltaTime);

		if (transform.localPosition.x <= resetPosX) {
			Vector3 newPos = new Vector3 (
				spawnPosX,
				transform.position.y,
				transform.position.z
			);
			transform.position = newPos;
		}
	}
}
