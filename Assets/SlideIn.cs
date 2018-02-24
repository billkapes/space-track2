using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlideIn : MonoBehaviour {
	public float slideFactor = 2f, speed = 1f, scaleFactor = 3f;
	SpriteRenderer SR;
	int posX, posY;
		

	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer>();
		posX = Random.Range(-10, 10);
		posY = Random.Range(-10, 10);	
		transform.DOMove( new Vector3(posX, posY), speed, false).SetSpeedBased(false).From();
//		transform.DOMove (new Vector3(transform.position.x * slideFactor, transform.position.y * slideFactor, 0f), speed, false).SetSpeedBased(false).From ();
		SR.DOFade(0f, 2).From();
		transform.DOScale (3, speed).From ();
	}
	void DoSlide() {
		posX = Random.Range(-10, 10);
		posY = Random.Range(-10, 10);	
		transform.DOMove( new Vector3(posX, posY), speed, false).SetSpeedBased(false).From();
//		transform.DOMove (new Vector3(transform.position.x * slideFactor, transform.position.y * slideFactor, 0f), speed, false).SetSpeedBased(false).From ();
		SR.DOFade(0f, 2).From();
		transform.DOScale (3, speed).From ();

	}

	void SlideOut() {
		transform.DOMove( new Vector3(posX, posY), speed, false).SetSpeedBased(false);
//		transform.DOMove (new Vector3(transform.position.x * slideFactor, transform.position.y * slideFactor, 0f), speed, false).SetSpeedBased(false).From ();
		SR.DOFade(0f, 2);
		transform.DOScale (3, speed);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
