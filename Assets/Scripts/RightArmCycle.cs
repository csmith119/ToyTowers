using UnityEngine;
using System.Collections;
//Coded by Christy Smith and Will Timpson
public class RightArmCycle : ToyCycle  {
	public Sprite[] parts;
	private string targetObject = "RightArm";
	private string pathToAssets = "Sprites/toyParts/RightArms";
	// Use this for initialization
	void Start () {
		//Sets the array of sprites with the Right Arm Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}
	void Update(){
		//Sets the array of sprites with the RightArm Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}

	//Uses the move part forward method of parent class with Right Arm sprites and Right Arm object
	public void OnClickHeadForward(){
		OnButtonChangePartForward (parts, targetObject);
		Debug.Log ("Forward");
	}
	//Uses the move part backward method of parent class with Right Arm sprites and Right Arm object	
	public void OnClickHeadBackward(){
		OnButtonChangePartBackward (parts, targetObject);
		Debug.Log ("Backward");
	}
}