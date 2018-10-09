using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpBar : MonoBehaviour {

    public GameObject groundMarker;
    public GameObject currentHeightMarker;
    public GameObject actualHeightMarker;
    public GameObject lastJumpMarker;
    public GameObject highestJumpMarker;

    private float maxBarValue = 240;
    private float maxHMeters = 3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FoundGround(bool grounded)
    {
        groundMarker.SetActive(grounded);
    }

    public void SetMyHeight(float height)
    {
        Vector3 currentPos = actualHeightMarker.GetComponent<RectTransform>().localPosition;

        float result;
        result = maxHMeters / height;
        result = 100 / result;
        result = result * 0.01f;
        result = maxBarValue * result;

        result -= 118;

        Vector3 newPos = new Vector3(result, currentPos.y, currentPos.z);
        actualHeightMarker.GetComponent<RectTransform>().localPosition = newPos;
    }

    public void SetLastJump(float distance)
    {
        Vector3 currentPos = lastJumpMarker.GetComponent<RectTransform>().localPosition;

        float result;
        result = maxHMeters / distance;
        result = 100 / result;
        result = result * 0.01f;
        result = maxBarValue * result;

        Debug.Log("Got in set last jump");
        Debug.Log("last jump dis" + distance);
        result -= 118;
        Debug.Log("last jump result: " + result);

        Vector3 newPos = new Vector3(result, currentPos.y, currentPos.z);
        lastJumpMarker.GetComponent<RectTransform>().localPosition = newPos;
    }

    public void SetHighestJump(float distance)
    {
        Vector3 currentPos = highestJumpMarker.GetComponent<RectTransform>().localPosition;

        float result;
        result = maxHMeters / distance;
        result = 100 / result;
        result = result * 0.01f;
        result = maxBarValue * result;

        Debug.Log("got in set highest jump");
        result -= 118;

        Vector3 newPos = new Vector3(result, currentPos.y, currentPos.z);
        highestJumpMarker.GetComponent<RectTransform>().localPosition = newPos;
    }

    public void SetCurrentHeight(float distanceToGround)
    {
        Vector3 currentPos = currentHeightMarker.GetComponent<RectTransform>().localPosition;

        float result;
        result = maxHMeters / distanceToGround;
        result = 100 / result;
        result = result * 0.01f;
        result = maxBarValue * result;
       
        //Debug.Log(result);
        result -= 118;

        Vector3 newPos = new Vector3(result, currentPos.y, currentPos.z);
        currentHeightMarker.GetComponent<RectTransform>().localPosition = newPos;
    }
}
