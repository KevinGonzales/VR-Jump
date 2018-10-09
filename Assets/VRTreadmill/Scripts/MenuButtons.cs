using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GotoHub()
    {
        SceneManager.LoadScene("HubLevel");
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoProfSetup()
    {
        SceneManager.LoadScene("ProfileSetup");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
