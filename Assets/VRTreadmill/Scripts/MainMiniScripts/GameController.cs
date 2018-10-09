using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// static variable single_instance of type Singleton
	private static GameController single_instance = null;
	private int timeForTile = 15;
	private int length = 11;
	private int width = 11;
	private int chanceForPowerUp = 10;
	private int chanceForHindrence= 10;
	// Use this for initialization
	void Start () {
		//set the values according to player preferences and give default values
		timeForTile = PlayerPrefs.GetInt ("timeForTile",15);
		length = PlayerPrefs.GetInt ("length",11);
		width = PlayerPrefs.GetInt ("width",11);
		chanceForPowerUp = PlayerPrefs.GetInt ("chanceForPowerUp",10);
		chanceForHindrence = PlayerPrefs.GetInt ("chanceForHindrence",10);
	}
		
	public void setChanceForHindrence(int chance){
		chanceForHindrence = chance;
		chanceForHindrence = PlayerPrefs.GetInt ("chanceForHindrence",chance);
	}
	public void setChanceForHindrenceFromUI(string text){
		int val = int.Parse(text);
		chanceForHindrence = val;
		PlayerPrefs.SetInt ("chanceForHindrence", val);
	}

	public int getChanceForHindrence(){
		return PlayerPrefs.GetInt ("chanceForHindrence",10);
	}

	public void setChanceForPowerUp(int chance){
		chanceForPowerUp = chance;
		PlayerPrefs.SetInt ("chanceForPowerUp",chance);
	}

	public void setchanceForPowerUpFromUI(string text){
		int val = int.Parse(text);
		chanceForPowerUp = val;
		PlayerPrefs.SetInt ("chanceForPowerUp", val);
	}

	public int getChanceForPowerUp(){
		return PlayerPrefs.GetInt ("chanceForPowerUp",10);
	}

	public int getLengthForTile(){
		return PlayerPrefs.GetInt ("length",11);
	}

	public void setLengthForTile(int lengths){
		length = lengths;
		PlayerPrefs.SetInt ("length", lengths);
	}
	public void setLengthForTileFromUI(string text){
		int val = int.Parse(text);
		length = val;
		PlayerPrefs.SetInt ("length", val);
	}

	public int getWidthForTiles(){
		return PlayerPrefs.GetInt ("width",11);
	}

	public void setWidthForTilesFromUI(string text){
		int val = int.Parse(text);
		width = val;
		PlayerPrefs.SetInt ("width", val);
	}

	public void setWidthForTiles(int widths){
		width = widths;
		PlayerPrefs.SetInt ("width", widths);
	}

	public float getTimeForTile(){
		return PlayerPrefs.GetInt ("timeForTile",15);
	}

	public void setTimeForTile(int time){
		timeForTile = time;
		PlayerPrefs.SetInt ("timeForTile",time);
	}

	public void setTimeForTileFromUI(string text){
		int val = int.Parse(text);
		timeForTile = val;
		PlayerPrefs.SetInt ("timeForTile", val);
	}



	// private constructor restricted to this class itself
	private GameController()
	{
	}

	public static GameController Instance
	{
		get 
		{
			if (single_instance == null)
			{
				single_instance = new GameController();
			}
			return single_instance;
		}
	}
		
}
