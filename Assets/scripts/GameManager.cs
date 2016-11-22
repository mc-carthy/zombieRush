using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[SerializeField]
	private GameObject mainMenu;

	private bool isGameStarted = false;
	public bool IsGameStarted {
		get {
			return isGameStarted;
		}
	}

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
		Assert.IsNotNull (mainMenu);
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

	public void EnterGame () {
		mainMenu.SetActive (false);
		isGameStarted = true;
	}
}