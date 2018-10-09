using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scoreboard : MonoBehaviour {

	public UserData[] allUserData;
	DataController dc = new DataController();
	Text text;
	string info;

	// Use this for initialization
	void Start () {
		text = GetComponent <Text>();
		dc.LoadGameData ();
		allUserData = dc.getAllUsers();
		for (int i = 0; i < allUserData.Length; i++) {
			Debug.Log (i);
			info += allUserData [i].name + " : " + allUserData [i].scores + " \n";
		}
		text.text = info;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
