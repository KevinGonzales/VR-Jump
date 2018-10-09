using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 100;

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    Vector3 trans;
    bool isJumping = false;
    public Transform toLocation = null;

    public JumpManager jumpWatcher;
    private int lastJumpCount = 0;

	private GameObject objHit;
	private Shader shade;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (toLocation != null)
            {
                endMarker = toLocation;
                isJumping = true;
                startTime = Time.time;
                startMarker = this.transform;
                trans = new Vector3(endMarker.transform.position.x, endMarker.transform.position.y + 1, endMarker.transform.position.z);
                journeyLength = Vector3.Distance(startMarker.position, trans);
            }
        }
        else if (jumpWatcher.jumpCount > lastJumpCount) //this way to jump with HTC vive headset
        {
            Debug.Log("jumped!!!");
            lastJumpCount = jumpWatcher.jumpCount;
            if (toLocation != null)
            {
                endMarker = toLocation;
                isJumping = true;
                startTime = Time.time;
                startMarker = this.transform;
                trans = new Vector3(endMarker.transform.position.x, endMarker.transform.position.y + 1, endMarker.transform.position.z);
                journeyLength = Vector3.Distance(startMarker.position, trans);
            }
        }

        if (isJumping)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, trans, fracJourney);
            if (trans == this.transform.position)
            {
                isJumping = false;
            }
        }


    }


    /*if (Input.GetButton ("Vertical"))_ {
        // ...also rotate around the World's Y axis
        transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }*/

    void FixedUpdate()
    {
        if (jumpWatcher == null)
            jumpWatcher = GameObject.FindGameObjectWithTag("JumpWatcher").GetComponent<JumpManager>();

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
	
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            Jumpable obj;
            try
            {
				
                obj = hit.transform.gameObject.GetComponent<Jumpable>();

				//if we hit another
				if(objHit != null){
					if(!GameObject.ReferenceEquals( obj, objHit)){
						objHit.transform.gameObject.GetComponent<Renderer>().material.shader  = shade;
						objHit = null;
					}
				}

                if (obj.getJumpable())
                {
                    toLocation = hit.transform;
					objHit = hit.transform.gameObject;
					shade = hit.transform.gameObject.GetComponent<Renderer>().material.shader;
					hit.transform.gameObject.GetComponent<Renderer>().material.shader  = Shader.Find("Self-Illumin/Outlined Diffuse");
                }
                else
                {
                    toLocation = null;
                }
					
            }
            catch
            {
				//kinda working
				if(objHit != null){
					objHit.transform.gameObject.GetComponent<Renderer>().material.shader  = shade;
					objHit = null;
				}
            }
            print("There is something in front of the object!");
        }


		//to check if you lost
		Vector3 down = transform.TransformDirection(Vector3.down);
		RaycastHit hitFloor;

		Debug.DrawLine(transform.position, down, Color.red);


		//looks like i need to make a layer mask
		if (Physics.Raycast (transform.position, down, out hitFloor, 10)) {
			if(hitFloor.transform.gameObject.tag != "Tile"){
				Debug.Log("Lost");
				GetComponent<Rigidbody> ().useGravity = true;
				StartCoroutine(WaitAndPrint(3));
			}
		}
		/*else
		{
			// executes if it doesnt hit any collider. SO you lost
			Debug.Log("Lost");
		}*/
    }

	private IEnumerator WaitAndPrint(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);
			print("WaitAndPrint " + Time.time);
			SceneManager.LoadScene("HubLevel");
		}
	}

}
