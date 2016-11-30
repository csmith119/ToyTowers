using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//Coded by Christy Smith
public class NewFriend : MonoBehaviour {
	//Panel that displays friends 
	[SerializeField] GameObject friendsPanel;
	[SerializeField] GameObject friendsMessage;
	Text message;
	//Count of how many Friends have been earned 
	private int friendsEarned=0;
	//The constant strings hold the folder path that is universal to the toy parts original location and the
	//new location, respectively. 
	private const string oldFolder = "Assets/Resources/Sprites/toyParts/FriendParts/";
	private const string newFolder = "Assets/Resources/Sprites/toyParts/";
	//Creates a string containing all used Toy parts. It will be used to reset them.  
	private string usedKeys;
	//Creates a string holding all available keys from PlayerPrefs in a CSV
	private string commaKeys;
	//Creates an array and a list to temporarily store and manage these keys
	private string[] arrayKeys;
	private List<string> Keys = new List<string>(); 

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

	// Use this for initialization
	void Start () {
		friendsPanel.SetActive (false);
		message = friendsMessage.GetComponent<Text> ();

		//sets variables from player prefs
		usedKeys = PlayerPrefs.GetString("used");
		commaKeys = PlayerPrefs.GetString ("keys");	

		//Creates a list holding all available keys
		arrayKeys = commaKeys.Split (',');
		for (int i = 0; i < arrayKeys.Length; i++) {
			Keys.Add (arrayKeys [i]);
		}
		Debug.Log ("count :" + Keys.Count);
	}

	//Adds new toy part into cycles
	public void addToyPart(){
		int index = Random.Range(0, Keys.Count);
		//Gets key from list and then removes it from the keys so it can't be accessed again
		string oldPathKey = Keys[index];
		Keys.RemoveAt (index);
		//Gets corresponding new path from the dictionary
		string newPathValue = movePaths[oldPathKey];
		//Moves new part from old path to new path 
		string move= "Didn't Work";
		move = AssetDatabase.MoveAsset (oldPathKey, newPathValue);
		Debug.Log (move);
		//Adds the key for the move to the UsedKeys String and sets it
		usedKeys= usedKeys + "," +  oldPathKey + "," + newPathValue;
		PlayerPrefs.SetString ("used", usedKeys);
	}

	//Simulates earning enough points to gain a friend
	public void addFriend(){
		friendsEarned++;
	}

	//Shows the friends pane to simulate all the blocks being tagged
	public void gameOver(){
		friendsPanel.SetActive (true);
		if (friendsEarned == 0) {
			message.text = "YOU'VE EARNED NO FRIENDS. TRY HARDER!";
		} else {
			message.text = "YOU'VE EARNED " + friendsEarned + " FRIENDS. WAY COOL!";
			for (int i = 0; i < friendsEarned; i++) {
				addToyPart ();
			}
		}
	}

	//Changes to ToyAssembly Scene 
	public void toToyAssembly(){
		SceneManager.LoadScene ("ToyAssembly");
	}
		
}
