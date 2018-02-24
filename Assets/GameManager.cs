using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public enum TurnState {
	player, enemy, none
}

public class GameManager : MonoBehaviour {
	public GameObject mainmenuPanel;
	public CanvasGroup panelGroup;
	public TurnState turn;
	public EnemyController[] enemys;
	public Vector3 destination;
	public GameObject gameBoard;
	public int level;

	PlayerController thePlayer;
	GameObject tempBoard;
	Animator menuAnim;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		menuAnim = GameObject.Find("Panel").GetComponent<Animator>();
		turn = TurnState.none;

		panelGroup.DOFade(0f, 0.75f).SetDelay(0.4f).From();



	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

		if (turn == TurnState.player && thePlayer.done == true) {
			thePlayer.canMove = false;
			thePlayer.done = false;
			turn = TurnState.enemy;
		}
		if (turn == TurnState.enemy) {
			turn = TurnState.none;
			UpdateEnemies();
			if (enemys.Length > 0) {
				foreach (var enemy in enemys) {
					enemy.BroadcastMessage("DoMove");
				}
			}

			Invoke("NextTurn", 1f);
		}



		if (Input.GetKeyDown(KeyCode.Space)) {
			InstantiateBoard();
			//BroadcastMessage("DoSlide");
		}
		if (Input.GetKeyDown(KeyCode.M)) {
			BroadcastMessage("SlideOut");

		}

		if (Input.GetKeyDown(KeyCode.D)) {
			Destroy(tempBoard, 1.1f);
		}
	}

	void InstantiateBoard() {
		tempBoard = Instantiate(gameBoard, transform) as GameObject;
		enemys = FindObjectsOfType<EnemyController>();
	}

	public void NextTurn() {
		turn = TurnState.player;
		//thePlayer.canMove = true;
		if (!thePlayer.hitGoal) {
			thePlayer.EnableMovers ();
			
		}

	}

	public void ResetTheBoard() {
		StartCoroutine(DoBoard());
		level += 1;

	}

	public IEnumerator DoBoard() {
		yield return new WaitForSeconds(1);
		BroadcastMessage("SlideOut");
		yield return new WaitForSeconds(1.1f);
		Destroy(tempBoard);
		yield return new WaitForSeconds(0.1f);
		InstantiateBoard();

	}

	public void UpdateEnemies() {
		enemys = null;
		enemys = FindObjectsOfType<EnemyController>();
	}


	public void StartButton() {
		//mainmenuPanel.transform.DOMoveY(1300, 1, false).SetRelative(true);
		menuAnim.SetTrigger("Press Start");
		InstantiateBoard();
		thePlayer.MoveIn();
		turn = TurnState.player;

		thePlayer.canMove = true;
	}

}
