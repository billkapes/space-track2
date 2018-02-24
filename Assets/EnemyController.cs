using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour {
	public float moveTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoMove() {
		Vector3 playerPos = GameObject.FindObjectOfType<PlayerController>().transform.position;
		Vector2 newPos;
		if (Random.Range(0, 2) == 0) {
			if (playerPos.x <= transform.position.x) {
				newPos.x = -1;
				newPos.y = 0;
			} else {
				newPos.x = 1;
				newPos.y = 0;
			}
		} else {
			if (playerPos.y <= transform.position.y) {
				newPos.x = 0;
				newPos.y = -1;
			} else {
				newPos.x = 0;
				newPos.y = 1;
			}
		}
		transform.DOMove(new Vector3 (newPos.x, newPos.y), moveTime, false).SetRelative();
	}
}
