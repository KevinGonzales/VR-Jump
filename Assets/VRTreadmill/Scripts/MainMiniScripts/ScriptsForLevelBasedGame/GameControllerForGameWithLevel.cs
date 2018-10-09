using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerForGameWithLevel : MonoBehaviour {

	//the game sceene will call this scripth instead of the other one and evrything will be determined via level

	// static variable single_instance of type Singleton
	private static GameControllerForGameWithLevel single_instance = null;
	private int timeForTile = 20;
	private int length = 2;
	private int width = 2;
	private int level =1;
	private int chanceForPowerUp = 50;
	private int chanceForHindrence= 0;
	// Use this for initialization
	void Start () {
		//set the values according to player preferences and give default values
		level = PlayerPrefs.GetInt ("level",1);
		setValuesBasedOfLevel ();
	}

	public void setLevel(int newLevel){
		PlayerPrefs.SetInt ("level",newLevel);
		level = newLevel;
		setValuesBasedOfLevel ();
	}

	public int getLevel(){
		return 	PlayerPrefs.GetInt ("level",1);
	}
	public void incrementLevel(){
		level = PlayerPrefs.GetInt ("level",1);
		level++;
		PlayerPrefs.SetInt ("level",level);
		setValuesBasedOfLevel ();
	}

	//this method is called to set the values based off the level
	public void setValuesBasedOfLevel(){
		length = 3 * level;
		width = 3 * level;
		//drop a second to jump each level  up to 3
		if ((timeForTile - level) >= 3) {
			timeForTile -= level;
		} else {
			timeForTile = 3;
		}
		if ((chanceForPowerUp - level) > 2) {
			chanceForPowerUp -= level;
		} else {
			chanceForPowerUp = 2;		
		}
		if ((chanceForHindrence + level) <50){
			chanceForHindrence += level;
		}

	}

	//we will only use get MEthods
	public int getChanceForHindrence(){
		return chanceForHindrence;
	}
		

	public int getChanceForPowerUp(){
		return chanceForPowerUp;
	}

	public int getLengthForTile(){
		return length;
	}


	public int getWidthForTiles(){
		return width;
	}


	public float getTimeForTile(){
		return timeForTile;
	}



	// private constructor restricted to this class itself
	private GameControllerForGameWithLevel()
	{
	}

	public static GameControllerForGameWithLevel Instance
	{
		get 
		{
			if (single_instance == null)
			{
				single_instance = new GameControllerForGameWithLevel();
			}
			return single_instance;
		}
	}

}
