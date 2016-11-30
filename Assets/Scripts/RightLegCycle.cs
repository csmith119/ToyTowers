using UnityEngine;
using System.Collections;

//Coded by Christy Smith and Will Timpson
public class RightLegCycle : ToyCycle  {
	public Sprite[] parts;
	private string targetObject = "RightLeg";
	private string pathToAssets = "Sprites/toyParts/RightLegs";
	// Use this for initialization
	void Start () {
		//Sets the array of sprites with the Right Leg Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}
	void Update(){
		//Sets the array of sprites with the RightLeg Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}

	//Uses the move part forward method of parent class with Right Leg sprites and RightLeg object
	public void OnClickHeadForward(){
		OnButtonChangePartForward (parts, targetObject);
		Debug.Log ("Forward");
	}
	//Uses the move part backward method of parent class with Right Leg sprites and RightLeg object	
	public void OnClickHeadBackward(){
		OnButtonChangePartBackward (parts, targetObject);
		Debug.Log ("Backward");
	}
}
