﻿using UnityEngine;
using System.Collections;

//Coded by Christy Smith and Will Timpson
public class LeftLegCycle : ToyCycle  {
	public Sprite[] parts;
	private string targetObject = "LeftLeg";
	private string pathToAssets = "Sprites/toyParts/LeftLegs";
	// Use this for initialization
	void Start () {
		//Sets the array of sprites with the Left Leg Sprites from Assets
		parts = Resources.LoadAll<Sprite> (pathToAssets);
	}

	//Uses the move part forward method of parent class with Left Leg sprites and LeftLeg object
	public void OnClickHeadForward(){
		OnButtonChangePartForward (parts, targetObject);
		Debug.Log ("Forward");
	}
	//Uses the move part backward method of parent class with Left Leg sprites and LeftLeg object	
	public void OnClickHeadBackward(){
		OnButtonChangePartBackward (parts, targetObject);
		Debug.Log ("Backward");
	}
}
