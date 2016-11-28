using UnityEngine;
using System.Collections;
//Coded by Christy Smith and Will Timpson
public class BodyCycle : ToyCycle  {
	public Sprite[] parts;
	private string targetObject = "Body";
	private string pathToAssets = "Sprites/toyParts/Bodies";
	// Use this for initialization
	void Start () {
		//Sets the array of sprites with the Body Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}
	void Update(){
		//Sets the array of sprites with the Body Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}

	//Uses the move part forward method of parent class with Body sprites and Body object
	public void OnClickHeadForward(){
		OnButtonChangePartForward (parts, targetObject);
		Debug.Log ("Forward");
	}
	//Uses the move part backward method of parent class with Body sprites and Body object	
	public void OnClickHeadBackward(){
		OnButtonChangePartBackward (parts, targetObject);
		Debug.Log ("Backward");
	}
}