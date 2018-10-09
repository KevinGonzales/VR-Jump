using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTIles : MonoBehaviour {

	public GameObject[] Tiles;
	public GameObject[] Hindrences;
	public GameObject[] PowerUps;
	private int increment = 1;
	public GameObject Player;
	public GameObject startingTile;
	// Use this for initialization
	void Start () {
		
		int length = GameController.Instance.getLengthForTile ();
		int width = GameController.Instance.getWidthForTiles ();

		Vector3 pos = Vector3.zero;

		for(int i =0;i<width;i++){
			
			pos.x += increment;
			pos.z = 0;

			//if its the first one instantiate with player
			if (i == 0) {
				Vector3 pPos = new Vector3 (1,1,0);
				Instantiate (startingTile, pos, Quaternion.identity);
				Instantiate (Player, pPos, Quaternion.identity);
			} else {
				int n = itemToInstantiate ();
				switch (n) {
				case 0:
					int item = Random.Range (0, Tiles.Length-1);
					Instantiate (Tiles [item], pos, Quaternion.identity);
					break;
				case 1:
					Instantiate ( Hindrences[Random.Range (0, Hindrences.Length )], pos, Quaternion.identity);
					break;
				case 2:
					Instantiate (PowerUps [Random.Range (0, PowerUps.Length )], pos, Quaternion.identity);
					break;
				}
			}

			for (int j = 0;j<length;j++){
				pos.z += increment;

				//if its the last tile we are instantiateing and the goal has still not been placed
				if (i == width - 1 && j == length - 1) {
					Instantiate (Tiles [1], pos, Quaternion.identity);
				} else { //else normal random
					switch (itemToInstantiate ()) {
					case 0:
						int item = Random.Range (0, Tiles.Length -1);
						Instantiate (Tiles [item], pos, Quaternion.identity);
						break;
					case 1:
						//Debug.Log (Hindrences.Length);
						Instantiate ( Hindrences[Random.Range (0, Hindrences.Length )], pos, Quaternion.identity);
						break;
					case 2:
						Instantiate (PowerUps [Random.Range (0, PowerUps.Length )], pos, Quaternion.identity);
						break;
					}
				}

			}
		}

	}

	//randomly returns what type of object we should instatntiate 
	private int itemToInstantiate(){
		//Debug.Log (Tiles.Length);
		int num = Random.Range (1,100);

		if(num <= GameController.Instance.getChanceForPowerUp()){
				return 2;
		}
		else if (GameController.Instance.getChanceForPowerUp () < num && num <= (GameController.Instance.getChanceForHindrence () + GameController.Instance.getChanceForPowerUp ())) {
				return 1;
		} else {
			return 0;
		}
	}
}
