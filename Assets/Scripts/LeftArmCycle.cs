using UnityEngine;
using System.Collections;

public class LeftArmCycle : ToyCycle  {
	public Sprite[] parts;
	private string targetObject = "LeftArm";
	private string pathToAssets = "Sprites/toyParts/LeftArms";
	// Use this for initialization
	void Start () {
		//Sets the array of sprites with the LeftArm Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}
	void Update(){
		//Sets the array of sprites with the LeftArm Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}

	//Uses the move part forward method of parent class with LeftArm sprites and LeftArm object
	public void OnClickHeadForward(){
		OnButtonChangePartForward (parts, targetObject);
	}
	//Uses the move part backward method of parent class with LeftArm sprites and LeftArm object	
	public void OnClickHeadBackward(){
		OnButtonChangePartBackward (parts, targetObject);
	}
}
