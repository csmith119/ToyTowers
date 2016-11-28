using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
//Coded by Christy Smith
public class NewFriend : MonoBehaviour {
	//Creates two arrays, one which holds the paths of all the hidden toy parts and a corresponding array 
	//that holds the location of where those parts should end up once they've been gained by the user
	private List<string> hiddenOldPath = new List<string>{ "Assets/Resources/Sprites/toyParts/FriendParts/duckHead.png",
		"Assets/Resources/Sprites/toyParts/FriendParts/WingLeftArm.png", 
		"Assets/Resources/Sprites/toyParts/FriendParts/WingRightArm.png" };
	private List<string> correspondingNewPath = new List<string> {"Assets/Resources/Sprites/toyParts/Heads/duckHead.png", 
		"Assets/Resources/Sprites/toyParts/LeftArms/wingLeftArm.png",
		"Assets/Resources/Sprites/toyParts/RightArms/wingRightArm.png"};
	//Adds new toy part into cycles
	public void addToyPart(){
		int index = Random.Range(0, hiddenOldPath.Count);
		//Gets random path from array and then removes it so it can't be accessed again
		string oldPath = hiddenOldPath [index];
		hiddenOldPath.RemoveAt (index);
		//Gets corresponding new path from array and then removes it so it can't be accessed again
		string newPath = correspondingNewPath [index];
		correspondingNewPath.RemoveAt (index);
		//Moves new part from old path to new path 
		string move= "Didn't Work";
		move = AssetDatabase.MoveAsset (oldPath, newPath);
		Debug.Log (move);
	}
}
