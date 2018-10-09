using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckScript : MonoBehaviour {

	private GameController controller;
	private float PowerUpTimer;
	private bool timerActive = false;

	private FrostEffect effect;
	private Vector3 ColliderStandardSize ;
	private BoxCollider boxCollider = null;

	void Start () {
		controller = GameController.Instance;
	}

	void FixedUpdate () {
		//startTimerWhenSpeher hits
		if (timerActive) {
			//decrement the timer
			//playerMovement.setStuck(true);
			PowerUpTimer -= Time.deltaTime;
			//Debug.Log ("Power up timer : time left is " + PowerUpTimer);
			if (PowerUpTimer <= 0) {
				//allow player to jump
				//Debug.Log ("PWorked");
				effect.disableFrost ();
				boxCollider.size = ColliderStandardSize;
			}

		}
	}
		

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player")
		{
			boxCollider = (BoxCollider) other;
			//Debug.Log ("set collider");
		}

		if (other.gameObject.tag == "DestoryWhenTouch") {
			ColliderStandardSize = boxCollider.size;
			boxCollider.size = new Vector3(0f,0f,0f); //how much bigger/smaller the collider should get
	
			//add frozen
			effect = Camera.main.GetComponent<FrostEffect>();
			effect.enableFrost ();

			//Time stuck
			timerActive = true;
			PowerUpTimer = GameController.Instance.getTimeForTile ()/2;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "DestoryWhenTouch")
		{
			boxCollider.size = ColliderStandardSize;
		}
	}


}
