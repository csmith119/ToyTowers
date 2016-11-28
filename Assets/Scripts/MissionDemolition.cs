using UnityEngine;
using System.Collections;

public enum Gamemode{
	idle, 
	playing, 
	levelEnd
}

public class MissionDemolition : MonoBehaviour {
	static public MissionDemolition S;

	public GameObject[] castles;
	public GUIText gtLevel;
	public GUIText gtScore;
	public Vector3 castlePos;

	public bool  _____________;

	public int level;
	public int levelMax;
	public int shotsTaken;
	public GameObject castle;
	public Gamemode mode = Gamemode.idle;
	public string showing = "Slingshot";

	// Use this for initialization
	void Start () {
		S = this;
		level = 0;
		levelMax = castles.Length;
		StartLevel ();
	}

	void StartLevel(){
		if (castle != null) {
			Destroy (castle);
		}

		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Projectile");
		foreach (GameObject pTemp in gos) {
			Destroy (pTemp);
		}

		castle = Instantiate (castles [level]) as GameObject;
		castle.transform.position = castlePos;
		shotsTaken = 0;

		SwitchView ("Both");
		ProjectileLine.S.Clear ();

		Goal.goalMet = false;

		ShowGT ();

		mode = Gamemode.playing;
	}

	void ShowGT(){
		gtLevel.text = "Level: " + (level + 1) + " of " + levelMax;
		gtScore.text = "Shots Taken: " + shotsTaken;
	}
	
	// Update is called once per frame
	void Update () {
		ShowGT ();

		if (mode == Gamemode.playing && Goal.goalMet) {
			mode  = Gamemode.levelEnd;

			SwitchView ("Both");

			Invoke ("NextLevel", 2f);
		}
	
	}
	void NextLevel(){
		level++;
		if (level == levelMax) {
			level = 0;
		}
		StartLevel ();
	}

	void OnGUI(){
		Rect buttonRect = new Rect ((Screen.width / 2) - 5, 10, 100, 24);

		switch (showing) {
		case "SlingShot":
			if (GUI.Button (buttonRect, "Show Castle")) {
				SwitchView ("Castle");
			}
			break;

		case "Castle":
			if (GUI.Button (buttonRect, "Show Both")) {
				SwitchView ("Both");
			}
			break;
		case "Both":
			if (GUI.Button (buttonRect, "Show Slingshot")) {
				SwitchView ("Slingshot");
			}
			break;
		}
	}

	static public void SwitchView( string eView){
		S.showing = eView;
		switch (S.showing) {
		case "Slingshot":
			FollowCam.S.poi = null;
			break;

		case "Castle":
			FollowCam.S.poi = S.castle;
			break;
		case "Both":
			FollowCam.S.poi = GameObject.Find ("ViewBoth");
			break;
		}
	}
	public static void ShotsFired(){
		S.shotsTaken++;
	}
}
