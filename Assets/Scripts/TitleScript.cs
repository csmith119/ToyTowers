using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;

public class TitleScript : MonoBehaviour {
	//The constant strings hold the folder path that is universal to the toy parts original location and the
	//new location, respectively. 
	private const string oldFolder = "Assets/Resources/Sprites/toyParts/FriendParts/";
	private const string newFolder = "Assets/Resources/Sprites/toyParts/";
	//Creates a delimeted string containing all of the toy part paths and then all the new paths
	private const string completeOldPaths = oldFolder + "duckHead.png," +
	 oldFolder + "wingLeftArm.png," + oldFolder + "wingRightArm.png," + oldFolder + "dragonHead.png," +
	 oldFolder + "heavyHitterBody.png," + oldFolder + "jacksBody.png," + oldFolder + "rainbowWheelLeftLeg.png," +
	 oldFolder + "rainbowWheelRightLeg.png," + oldFolder + "rocketLeftLeg.png," + oldFolder + "rocketRightLeg.png," +
	 oldFolder + "rollerRightLeg.png," + oldFolder + "rollerLeftLeg.png," +
	 oldFolder + "springLeftArm.png," + oldFolder + "springRightArm.png," + oldFolder + "turtleBody.png";
	private const string completeNewPaths = newFolder + "Heads/duckHead.png," + newFolder + "LeftArms/wingLeftArm.png,"
	 + newFolder + "RightArms/wingRightArm.png," + newFolder + "Heads/dragonHead.png," + newFolder +
	 "Bodies/heavyHitterBody.png," + newFolder + "Bodies/jacksBody.png," + newFolder +
	 "LeftLegs/rainbowWheelLeftLeg.png," + newFolder + "RightLegs/rainbowWheelRightLeg.png," + newFolder +
	 "LeftLegs/rocketLeftLeg.png," + newFolder + "RightLegs/rocketRightLeg.png," + newFolder +
	 "LeftLegs/rollerLeftLeg.png," + newFolder + "RightLegs/rollerRightLeg.png," + newFolder +
	 "LeftArms/springLeftArm.png," + newFolder + "RightArms/springRightArm.png," + newFolder +
	 "Bodies/turtleBody.png";
	
	private string usedPaths;
	private string[] usedParts;
	// Use this for initialization
	void Start () {
		//Gets the string containing all of the keys that were used and then creates an array of all the CSV	
		usedPaths = PlayerPrefs.GetString ("used");
		usedParts = usedPaths.Split (',');
		Debug.Log (usedParts.Length);
		/*if (PlayerPrefs.HasKey ("used") && usedPaths != "") {
			//Reset Toy Parts at The Beginning of the game
			for (int i = 0; i < usedParts.Length; i = i + 2) {
				string start = usedParts [i];
				string end = usedParts [i + 1];
				string moveBack = AssetDatabase.MoveAsset (end, start);
			}
		}*/
	//Reset the used parts playerPrefs once the toys have been reset
		PlayerPrefs.SetString("used", "");
	//Set Keys and Values PlayerPrefs
		PlayerPrefs.SetString("keys", completeOldPaths);
		PlayerPrefs.SetString ("values", completeOldPaths);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Load ToyAssembly when player hits Play
	public void startGame(){
		SceneManager.LoadScene ("ToyAssembly");
	}
}
