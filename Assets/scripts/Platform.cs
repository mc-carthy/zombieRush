using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	[SerializeField]
	private float speedX = 2;
	[SerializeField]
	private float resetPosX = -30f;
	[SerializeField]
	private float spawnPosX = 31f;

	protected virtual void Update () {

		if (!GameManager.instance.IsGameOver) {
			transform.Translate(Vector3.left * speedX * Time.deltaTime);

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
}
