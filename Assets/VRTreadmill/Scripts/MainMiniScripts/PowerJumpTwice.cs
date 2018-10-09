using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerJumpTwice : MonoBehaviour {

	//allows you to jump twice as far. SHould probably have a gui that tells them but they will also be able to select more tiles

	private Vector3 ColliderStandardSize ;
	private BoxCollider boxCollider = null;
	private ParticleEffect effect;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player")
		{
			boxCollider = (BoxCollider) other;
			Debug.Log ("set collider");
		}

		if (other.gameObject.tag == "DestoryWhenTouch") {
			effect = Camera.main.GetComponent<ParticleEffect>();
			effect.enableFrost ();

			ColliderStandardSize = boxCollider.size;
			boxCollider.size = new Vector3(5.4f,.13f,5.4f); //how much bigger the collider should get
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "DestoryWhenTouch")
		{
			boxCollider.size = ColliderStandardSize;
			effect.disableFrost ();
		}
	}
		


}
