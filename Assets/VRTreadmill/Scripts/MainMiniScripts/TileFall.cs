using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileFall : MonoBehaviour {

	GameController controller;
	private float fallTimer;
	bool timerActive = false;
	//private Text displayTime ; make this the time left

	void Start () {
		controller = GameController.Instance;
	}
	
	void FixedUpdate () {
		//Debug.Log (timerActive);
		if (timerActive) {
			//also show time left
			//displayTime = GameObject.FindGameObjectWithTag("TimeBeforeTileFalls").GetComponent<Text>();

			//displayTime.text = fallTimer.ToString();

			//Debug.Log ("in if");
			//decrement the timer
			fallTimer -= Time.deltaTime;
			//Debug.Log (fallTimer);
			if (fallTimer <= 0) {
				Destroy (this.gameObject); //will destroy it instead of making it fall. Later on add on a cool destroy effect
				//Debug.Log ("falling");
			}

		}
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("TileFall collision");
		if (other.gameObject.tag == "DestoryWhenTouch") {
			//Debug.Log ("touched player");
			timerActive = true;
			fallTimer = GameController.Instance.getTimeForTile ();
			//Debug.Log (fallTimer);
		}
	}

}
