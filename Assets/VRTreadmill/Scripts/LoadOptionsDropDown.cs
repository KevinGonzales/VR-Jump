using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOptionsDropDown : MonoBehaviour {

    public DataController dataController;
    public Profile profile;
    private Dropdown dropDown;
    public UserData loadUser;

    // Use this for initialization
    void Start()
    {
        dropDown = GetComponent<Dropdown>();
        dataController.LoadGameData();
        for (int i = 0; i < dataController.allUserData.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(dataController.allUserData[i].name);
            dropDown.options.Add(option);
        }
    }

    public void LoadProfile()
    {
        loadUser = dataController.getUser(dropDown.captionText.text);
        profile.username = loadUser.name;
        profile.height = float.Parse(loadUser.height);
        profile.jumpTolerance = float.Parse(loadUser.tippyToeHeight);

        SceneManager.LoadScene("HubLevel");
    }
	
}
