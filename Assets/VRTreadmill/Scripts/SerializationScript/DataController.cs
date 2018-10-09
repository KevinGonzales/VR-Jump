using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour {

	private GameData loadedData;

	public UserData[] allUserData;
	private string gameDataProjectFilePath = "/StreamingAssets/data.json";

	private string gameDataFileName = "data.json";

	// Use this for initialization
	void Start () {
		LoadGameData ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// This loads the reads the JSON File.
	public void LoadGameData(){
		string filePath = Path.Combine (Application.streamingAssetsPath, gameDataFileName);

		if (File.Exists (filePath)) {
			string dataAsJson = File.ReadAllText (filePath);
			loadedData = JsonUtility.FromJson<GameData> (dataAsJson);
			allUserData = loadedData.allUserData;
		} else {
			Debug.LogError ("Cannot load game data!");
		}
	
	}

	// This Updates the JSON File.
	private void saveGameData(){
		string dataAsJson = JsonUtility.ToJson (loadedData);
		for(int i = 0; i < allUserData.Length; i++)
			Debug.Log (allUserData [i].name);
		Debug.Log (dataAsJson);
		string filePath = Application.dataPath + gameDataProjectFilePath;
		File.WriteAllText (filePath, dataAsJson);
	}

	public UserData getUser(string userName){
		LoadGameData ();
		for (int i = 0; i < allUserData.Length; i++) {
			if (allUserData [i].name.Equals(userName)) {
				return allUserData [i];
			}
		}
		Debug.Log ("User not found.");
		return null;
	}
		

	public void updateData(UserData Data){
		if (allUserData == null) {
			LoadGameData ();
			Debug.Log ("Just retrieved the Users");
		}

		for (int i = 0; i < allUserData.Length; i++) {
			if (allUserData [i].name.Equals (Data.name)) {
				allUserData [i].name = Data.name;
				allUserData [i].height = Data.height;
				allUserData [i].tippyToeHeight = Data.tippyToeHeight;
				allUserData [i].scores = Data.scores;
				saveGameData ();
				return;
			}
		}

		UserData[] updatedUserData = new UserData[allUserData.Length + 1];

		for(int i = 0; i < allUserData.Length; i++)
			updatedUserData [i] = allUserData [i];

		updatedUserData [allUserData.Length] = Data;

		allUserData = updatedUserData;

		loadedData.allUserData = allUserData;

		saveGameData ();

	}

	public UserData[] getAllUsers(){

		return allUserData;
	
	}
		

}
