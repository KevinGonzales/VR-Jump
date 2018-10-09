using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour {

	public bool jumpable = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            jumpable = true;
            //Debug.Log ("Enter The player is "+jumpable);
        }
    }

	void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            jumpable = false;
            //Debug.Log("Exit The player is " + jumpable);
        }
    }

	public bool getJumpable(){
		return jumpable;
	}
}
