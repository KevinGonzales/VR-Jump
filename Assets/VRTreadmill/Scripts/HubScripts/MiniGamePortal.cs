using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGamePortal : MonoBehaviour {
    
    public GameObject portalUI;
    public string MinigameUIName;
    public string MinigameSceneName;

    private bool onTrigger = false;
    float timer = 0.0f;
    public int secTillTrans = 5;   //Seconds till transition into new scene
    private int secPassTrans = 0;   //Seconds passed since entered trigger

    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () {
        if (onTrigger == true)
        {
            timer += Time.deltaTime;
            secPassTrans = (int)timer % 60;
            string textStr = "Transitioning to " + MinigameUIName;
            if(secTillTrans - secPassTrans == 1)
            {
                textStr += " in " + (secTillTrans - secPassTrans) + " second.";
            }
            else
            {
                textStr += " in " + (secTillTrans - secPassTrans) + " seconds.";
            }
            portalUI.GetComponent<Text>().text = textStr;
        }

        if(secPassTrans >= secTillTrans)
        {
            //Transition scene
            SceneManager.LoadScene(MinigameSceneName);
        }
    }

    void OnTriggerEnter(Collider other) {
        onTrigger = true;
        timer = 0.0f;
        secPassTrans = 0;
        portalUI.active = true;
    }

    void OnTriggerExit(Collider other)
    {
        portalUI.active = false;
        onTrigger = false;
    }
}
