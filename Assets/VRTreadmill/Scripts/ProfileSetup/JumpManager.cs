using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class JumpManager : MonoBehaviour
{
    private Profile playerProfile;
    private JumpBar jumpBar;

    private RaycastHit hit;
    public float distanceToGround = 0;
    public float highestPoint = 0;
    public bool midJump = false;
    public int jumpCount = 0;

    //saved values
    public float jumpTolerance = 0;
    public float playerHeight = 0;

    // Use this for initialization
    void Start()
    {
        playerProfile = GameObject.FindGameObjectWithTag("PlayerProf").GetComponent<Profile>();
        jumpBar = GameObject.FindGameObjectWithTag("JumpBar").GetComponent<JumpBar>();
        playerHeight = playerProfile.height;
        jumpTolerance = playerProfile.jumpTolerance;

        jumpBar.SetMyHeight(playerHeight);
        jumpBar.SetHighestJump(0);
        jumpBar.SetLastJump(0);
    }

    public void SetProfileHeight(float height)
    {
        playerHeight = height;
        jumpBar.SetMyHeight(playerHeight);
    }

    public void SetTolerance(float tolerance)
    {
        jumpTolerance = tolerance;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("distance to ground " + distanceToGround);
        //watch for jumps count
        hit = new RaycastHit();

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            jumpBar.FoundGround(true);
            distanceToGround = hit.distance;
            jumpBar.SetCurrentHeight(distanceToGround);

            //figure out if we jumped
            if (distanceToGround > (playerHeight + jumpTolerance + .05f) && !midJump)
            {
                midJump = true;
                //we're guessing that the player jumped here, maybe wrong, they could have stood on tippy toes
                //this method may not work in the end, needs more research and play testing
                jumpCount++;
                Debug.Log(jumpCount);
                //if (jumpTolerance > 0)
                //{
                //    Debug.Log("last jump distance To ground: " + distanceToGround);
                //    jumpBar.SetLastJump(distanceToGround);
                //}
                //if (distanceToGround > highestPoint)
                //{
                //    highestPoint = distanceToGround;
                //    if (jumpTolerance > 0)
                //    {
                //        jumpBar.SetHighestJump(distanceToGround);
                //    }
                //}
            }
            else if (midJump && distanceToGround < (playerHeight + jumpTolerance))
            {
                midJump = false;
            }
        }
        else
        {
            jumpBar.FoundGround(false);
        }
    }

}
