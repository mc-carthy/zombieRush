using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private bool isPlayerActive = false;
	public bool IsPlayerActive {
		get {
			return isPlayerActive;
		}
	}

	private bool isGameOver = false;
	public bool IsGameOver {
		get {
			return isGameOver;
		}
	}

	private void Awake () {
		MakeSingleton ();
	}

	private void MakeSingleton () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			DestroyImmediate (gameObject);
		}
	}

	public void PlayerCollided () {
		isGameOver = true;
		isPlayerActive = false;
	}

	public void PlayerStartedGame () {
		isPlayerActive = true;
	}
}