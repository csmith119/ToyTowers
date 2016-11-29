using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
//Coded by Christy Smith
public class NewFriend : MonoBehaviour {
	//The constant strings hold the folder path that is universal to the toy parts original location and the
	//new location, respectively. 
	private const string oldFolder = "Assets/Resources/Sprites/toyParts/FriendParts/";
	private const string newFolder = "Assets/Resources/Sprites/toyParts/";
	//Creates an empty list which will contain the strings from Keys once they have been used. It will be used
	// for resetting the toy parts. 
	private List<string> usedKeys = new List <string>();
	//Creates a list which holds all of the keys for the movePaths Dictionary
	private List<string> Keys = new List <string> {oldFolder + "duckHead.png",
		oldFolder + "wingLeftArm.png",oldFolder + "wingRightArm.png",oldFolder + "dragonHead.png",
		oldFolder + "heavyHitterBody.png", oldFolder + "jacksBody.png", oldFolder + "rainbowWheelLeftLeg.png",
		oldFolder + "rainbowWheelRightLeg.png", oldFolder + "rocketLeftLeg.png", oldFolder + "rocketRightLeg.png",
		oldFolder + "rollerRightLeg.png", oldFolder + "rollerLeftLeg.png",
		oldFolder + "springLeftArm.png", oldFolder + "springRightArm.png", oldFolder + "turtleBody.png"};
	//Creates a dictionary, where the key is the original location of the toy part and the value holds 
	//the location of where those parts should end up once they've been gained by the user. 
	private Dictionary<string, string> movePaths = new Dictionary <string,string> {
		{oldFolder + "duckHead.png", newFolder + "Heads/duckHead.png"},
		{oldFolder + "wingLeftArm.png", newFolder + "LeftArms/wingLeftArm.png"},
		{oldFolder + "wingRightArm.png", newFolder + "RightArms/wingRightArm.png"},
		{oldFolder + "dragonHead.png", newFolder + "Heads/dragonHead.png"},
		{oldFolder + "heavyHitterBody.png", newFolder + "Bodies/heavyHitterBody.png"},
		{oldFolder + "jacksBody.png", newFolder + "Bodies/jacksBody.png"},
		{oldFolder + "rainbowWheelLeftLeg.png", newFolder + "LeftLegs/rainbowWheelLeftLeg.png"},
		{oldFolder + "rainbowWheelRightLeg.png", newFolder + "RightLegs/rainbowWheelRightLeg.png"},
		{oldFolder + "rocketLeftLeg.png", newFolder + "LeftLegs/rocketLeftLeg.png"},
		{oldFolder + "rocketRightLeg.png", newFolder + "RightLegs/rocketRightLeg.png"},
		{oldFolder + "rollerLeftLeg.png", newFolder + "LeftLegs/rollerLeftLeg.png"},
		{oldFolder + "rollerRightLeg.png", newFolder + "RightLegs/rollerRightLeg.png"},
		{oldFolder + "springLeftArm.png", newFolder + "LeftArms/springLeftArm.png"},
		{oldFolder + "springRightArm.png", newFolder + "RightArms/springRightArm.png"},
		{oldFolder + "turtleBody.png", newFolder + "Bodies/turtleBody.png"}};

	//Adds new toy part into cycles
	public void addToyPart(){
		int index = Random.Range(0, Keys.Count);
		Debug.Log (index);
		Debug.Log (Keys.Count);
		//Gets key from list and then removes it from the keys so it can't be accessed again
		string oldPathKey = Keys[index];
		Keys.RemoveAt (index);
		//Gets corresponding new path from the dictionary
		string newPathValue = movePaths[oldPathKey];
		//Moves new part from old path to new path 
		string move= "Didn't Work";
		move = AssetDatabase.MoveAsset (oldPathKey, newPathValue);
		Debug.Log (move);
		//Adds the key for the move to the UsedKeys List
		usedKeys.Add(oldPathKey);
	}

	//Moves the toy parts back to their original folder
	public void resetToys(){
		//Goes through each item of usedKeys and uses the string to access the dictionary and set back the 
		//toy parts
		for (int i = 0; i < usedKeys.Count; i++) {
			string resetKey = usedKeys [i];
			string resetValue = movePaths[resetKey];
			string moveBack = AssetDatabase.MoveAsset (resetValue, resetKey);
		}
	}
}
