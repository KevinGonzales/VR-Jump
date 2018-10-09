using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSetParent : MonoBehaviour {
    public GameObject newParent;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (newParent == null)
        {
            newParent = GameObject.FindGameObjectWithTag("PlayerMovement");
            transform.SetParent(newParent.GetComponent<Transform>());
        }
    }
}
