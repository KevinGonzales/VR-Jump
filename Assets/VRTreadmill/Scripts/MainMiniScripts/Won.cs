using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour {

	private Timer timer;

	// Use this for initialization
	void Start () {
		
		GameObject scriptsContainer = GameObject.Find ("Scripts");
		timer = scriptsContainer.GetComponent<Timer>();
		//Debug.Log ("WORKED");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "DestoryWhenTouch") {
			//You WON!!
			timer.stopTheTimer();
		}
	}


}
