using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	EnemyController[] enemies;
	GameObject goal;
	GameManager theGM;

	public GameObject enemyPrefab, obstacle;


	// Use this for initialization
	void Start () {
		theGM = FindObjectOfType<GameManager>();

		for (int i = 0; i < theGM.level + 1; i++) {
			Instantiate(obstacle, new Vector3(Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity, transform);
		}
		
		for (int i = 0; i < theGM.level + 1; i++) {
			Instantiate(enemyPrefab, transform);
		}

		enemies = GetComponentsInChildren<EnemyController>();	
		foreach (var enemy in enemies) {
			enemy.transform.position = new Vector3(Random.Range(-3, 6), Random.Range(-3, 2));
		}
		goal = GameObject.FindWithTag("Goal");
		goal.transform.position = new Vector3(Random.Range(1, 6), Random.Range(-3, 1));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
