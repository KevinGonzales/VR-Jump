using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImageRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(2, 0, 0));
    }
}
