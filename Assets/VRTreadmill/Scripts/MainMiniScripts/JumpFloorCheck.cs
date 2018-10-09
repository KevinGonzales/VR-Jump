using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpFloorCheck : MonoBehaviour
{
    //TODO
    //Jump counting/detecting the event of a jump
    //ability to set height in game
    //clean up jump info board

    private float highestJump = 0;
    public float jumpTolerance = .1f;

    private bool midJump = false;
    private int jumpCount = 0;
    public float playerHeight = 1.5f;

    public Text jumpCountText;
    public Text highestJumpText;
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            float distanceToGround = hit.distance;

            //figure out if we jumped
            if(distanceToGround > (playerHeight + jumpTolerance) && !midJump)
            {
                midJump = true;
                //we're guessing that the player jumped here, maybe wrong, they could have stood on tippy toes
                //this method may not work in the end, needs more research and play testing
                jumpCount++;
                jumpCountText.text = "Jump count: " + jumpCount;
            }
            else if (midJump && distanceToGround < (playerHeight + jumpTolerance))
            {
                midJump = false;
            }

            //detect new highest jump
            if (distanceToGround > highestJump)
            {
                highestJump = distanceToGround;
                //Debug.Log("New highest jump: " + highestJump);
                highestJumpText.text = "Highest jump: " + highestJump;
            }
        }

    }
}
