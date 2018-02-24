using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveShip : MonoBehaviour {
	
	PlayerController thePlayer;
	public float moveTime;

	// Use this for initialization
	void Awake () {
		
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		if (thePlayer.canMove) {
			thePlayer.Move(transform);
		}
	}

	void OnEnable() {
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(transform.DOMove(thePlayer.gameObject.transform.position, moveTime, false).SetSpeedBased(false).From());
		mySequence.Insert(0, transform.DOScale(0.15f, moveTime).From());
		mySequence.OnComplete(RoundPosition);
		//myCollider.enabled = false;
	}

	void RoundPosition() {
		transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		thePlayer.canMove = true;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			gameObject.SetActive(false);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Wall") {
			
		}
	}
}
