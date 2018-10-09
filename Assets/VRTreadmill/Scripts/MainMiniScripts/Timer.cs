using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timerLabel;
	private float time;
	private string stringTime;
	private bool stopTimer = false;

	void Update() {
		if (stopTimer) {
			//do nothing (dont inrement timer)s
		} else {
			time += Time.deltaTime;

			var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
			var seconds = time % 60;//Use the euclidean division for the seconds.
			var fraction = (time * 100) % 100;

			//Uncooment this to show time before falling
			//timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction); 

			stringTime = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

			//Debug.Log ("THE TIME IS " + stringTime);
			//update the label value
		}
	}

	public string getTime(){
		return stringTime;
	}

	public void stopTheTimer(){
		stopTimer = true;
	}
}
