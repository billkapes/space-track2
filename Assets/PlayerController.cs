using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public GameObject movers, explosion;
	public float moveTime;
	public bool canMove, done, hitGoal;
	public GameObject[] moveShips;
	GameManager theGM;

	// Use this for initialization
	void Start () {
		theGM = FindObjectOfType<GameManager> ();



	}
		

	// Update is called once per frame
	void Update () {
		
	}

	public void MoveIn() {
		transform.DOMove (new Vector3 (-5f, 3f), 1, false).SetDelay(1).OnComplete(EnableMovers);

	}

	public void Move(Transform moveTo) {
		if (theGM.turn == TurnState.player && canMove) {
			canMove = false;
			movers.SetActive(false);

			transform.DOMove(moveTo.position, moveTime, false).OnComplete(SetDone);
		}

	}
	void SetDone() {
		done = true;
	}

	public void EnableMovers() {
		transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		movers.SetActive(true);
		foreach (var moveShip in moveShips) {
			if (!moveShip.activeInHierarchy) {
				moveShip.SetActive(true);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Goal" && !hitGoal) {
			hitGoal = true;
			Sequence move1 = DOTween.Sequence();
			move1.Append( transform.DOMove(new Vector2(4f, 1f), 2, false) ).SetRelative(true);
			move1.Insert( 0, transform.DOScale(new Vector2(2f, 2f), 2) );
			move1.OnComplete(Move2);

			theGM.ResetTheBoard();
		}

		if (other.tag == "Enemy" && !hitGoal && theGM.turn == TurnState.player) {
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			theGM.UpdateEnemies();
		} else if (other.tag == "Enemy" && !hitGoal && theGM.turn != TurnState.player) {
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}




	}

	void Move2() {
		Sequence move2 = DOTween.Sequence();
		move2.SetDelay(1);
		move2.Append( transform.DOMove (new Vector2 (-5f, 3f), 1, false) );
		move2.Insert( 1, transform.DOScale(new Vector2(1f, 1f), 2) );
		move2.OnComplete(HitGoalFalse);
	}

	void HitGoalFalse() {
		hitGoal = false;
		EnableMovers();
	}




}
