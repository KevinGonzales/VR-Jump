using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextButton : MonoBehaviour {
    //This "Next Button" controls the profile setup sequence
    private Profile playerProfile;
    public JumpManager jumpManager;

    public int currentSeqNum = 0;
    public GameObject keyboard;
    public GameObject profName;
    public GameObject heightMenu;
    public GameObject ttMenu;
    public GameObject jumpMenu;

    public Text ttHeightText;
    public Text heightText;
    public Text jumpCounterText;

    private RaycastHit hit;
    public float distanceToGround = 0;
    public float highestPoint = 0;
    public bool midJump = false;
    public int jumpCount = 0;

    //saved values
    public float jumpTolerance = 0;
    public float playerHeight = 0;

    // Use this for initialization
    void Start () {
        playerProfile = GameObject.FindGameObjectWithTag("PlayerProf").GetComponent<Profile>();

        keyboard = GameObject.FindGameObjectWithTag("ProfNameKeyboard");
        profName = GameObject.FindGameObjectWithTag("ProfNameText");
        heightMenu = GameObject.FindGameObjectWithTag("HeightMenu");
        ttMenu = GameObject.FindGameObjectWithTag("TTMenu");
        jumpMenu = GameObject.FindGameObjectWithTag("JumpMenu");

        heightText = GameObject.FindGameObjectWithTag("HeightTracker").GetComponent<Text>();
        ttHeightText = GameObject.FindGameObjectWithTag("TippyToeTracker").GetComponent<Text>();
        jumpCounterText = GameObject.FindGameObjectWithTag("JumpTracker").GetComponent<Text>();

        heightMenu.SetActive(false);
        ttMenu.SetActive(false);
        jumpMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        switch (currentSeqNum)
        {
            case 1:
                //adjust height
                hit = new RaycastHit();

                if (Physics.Raycast(transform.position, -Vector3.up, out hit))
                {
                    Debug.Log("got in case: " + currentSeqNum);
                    distanceToGround = hit.distance;
                    //Debug.Log("distance to ground " + distanceToGround);
                    heightText.text = "Your Height: " + distanceToGround.ToString("F2");
                    playerHeight = distanceToGround;
                }
                break;
            case 2: //adjust the tippy toe height
                hit = new RaycastHit();

                if (Physics.Raycast(transform.position, -Vector3.up, out hit))
                {
                    distanceToGround = hit.distance;
                    if (distanceToGround > highestPoint)
                    {
                        highestPoint = distanceToGround;
                        ttHeightText.text = "Highest point: " + highestPoint.ToString("F2");
                        jumpTolerance = highestPoint - playerHeight;
                    }
                }
                break;
            case 3:
                //adjust jump count
                hit = new RaycastHit();

                if (Physics.Raycast(transform.position, -Vector3.up, out hit))
                {
                    distanceToGround = hit.distance;

                    //figure out if we jumped
                    if (distanceToGround > (playerHeight + jumpTolerance + .05f) && !midJump)
                    {
                        midJump = true;
                        //we're guessing that the player jumped here, maybe wrong, they could have stood on tippy toes
                        //this method may not work in the end, needs more research and play testing
                        jumpCount++;
                        jumpCounterText.text = "Jump count: " + jumpCount;
                    }
                    else if (midJump && distanceToGround < (playerHeight + jumpTolerance))
                    {
                        midJump = false;
                    }
                }
                    break;
            default:
                break;
        }
    }


    public void NextPressed()
    {
        Debug.Log("get in next pressed");
        switch (currentSeqNum)
        {
            case 0:
                Debug.Log("case 0");
                //Hide the profile name menu/keyboard
                keyboard.SetActive(false);
                //save the prof name
                //show the height menu
                heightMenu.SetActive(true);
                break;
            case 1:
                //save the height
                jumpManager.SetProfileHeight(playerHeight);
                //hide height menu
                heightMenu.SetActive(false);
                //show tippy toes height menu
                ttMenu.SetActive(true);
                break;
            case 2:
                //save tippy toes height
                jumpManager.SetTolerance(jumpTolerance);
                //hide tippy toes height menu
                ttMenu.SetActive(false);
                //show Jump! menu
                jumpMenu.SetActive(true);
                break;
            case 3:
                //save jump data
                //hide Jump! menu
                jumpMenu.SetActive(false);
                //show all prof settings menu and "press next to save & leave"
                //save everything to prof Data file
                playerProfile.UpdateSettings(profName.GetComponent<Text>().text, jumpTolerance, playerHeight);
                //leave the scene
                SceneManager.LoadScene("Tutorial");
                break;
            //case 4:

            //    break;
            default:
                print("invalid case state reached.");
                break;
        }

        currentSeqNum++;
    }

    //public void BackPressed()
    //{

    //}
}
