using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour {

    public string username;
    public float jumpTolerance;
    public float height;

    public DataController dataController;

    void Awake() //This will make this object persistent between game scenes
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        dataController.LoadGameData();

    }
	

    public void UpdateSettings(string newName, float tolerance, float newHeight)
    {
        tolerance = Mathf.Round(tolerance * 100f) / 100f;
        newHeight = Mathf.Round(newHeight * 100f) / 100f;
        username = newName;
        jumpTolerance = tolerance;
        height = newHeight;

        SaveToFile();
    }

    public void SaveToFile()
    {
        UserData data = new UserData();
        data.tippyToeHeight = jumpTolerance.ToString();
        data.height = height.ToString();
        data.name = username;

        dataController.updateData(data);
    }

}
