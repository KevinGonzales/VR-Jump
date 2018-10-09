using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

    /*
     * OnClickNewGame(): When the new game button is clicked.
     * 
     * 
     */
    public void OnClickNewGame()
    {
        //Create New Game
        SceneManager.LoadScene("HubLevel");
    }

    /*
     * OnClickLoadGame(): When the load game button is clicked.
     * 
     * 
     */
    public void OnClickLoadGame()
    {
        //Load Game

    }

    /*
     * OnClickQuit(): When the quit button is clicked.
     * 
     * 
     */
    public void OnClickQuit()
    {
        //Quit Game
        Application.Quit();
    }
}
