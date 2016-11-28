using UnityEngine;
using System.Collections;
//Coded by Christy Smith and Will Timpson
public class HeadCycle : ToyCycle  {
	public Sprite[] parts;
	private string targetObject = "Head";
	private string pathToAssets = "Sprites/toyParts/Heads";
	// Use this for initialization
	void Start () {
		//Sets the array of sprites with the Head Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}
	void Update(){
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}

	//Uses the move part forward method of parent class with head sprites and head object
	public void OnClickHeadForward(){
		OnButtonChangePartForward (parts, targetObject);
		Debug.Log ("Forward");
	}
	//Uses the move part backward method of parent class with head sprites and head object	
	public void OnClickHeadBackward(){
		OnButtonChangePartBackward (parts, targetObject);
		Debug.Log ("Backward");
	}
}
