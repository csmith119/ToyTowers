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
	public Vector3 enemyCastlePos = new Vector3 (50f, -9.5f, 0);
	public Vector3 playerCastlePos;
	public int level;
	public int levelMax;
	public int shotsTaken;
	public GameObject enemyCastle;
	public GameObject playerCastle;
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
		if (enemyCastle != null) {
			Destroy (enemyCastle);
		}
		if (playerCastle != null) {
			Destroy (playerCastle);
		}


		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Projectile");
		foreach (GameObject pTemp in gos) {
			Destroy (pTemp);
		}

		enemyCastle = Instantiate (castles [level]) as GameObject;
		enemyCastle.tag = "enemyBlock";
//		foreach (Transform t in transform) {
//			t.gameObject.tag = "enemyBlock";
//		}
		enemyCastlePos = new Vector3 (50f, -9.5f, 0);
		enemyCastle.transform.position = enemyCastlePos;
		//transform.FindChild
//		Object[] enemyChildren = enemyCastle.GetComponentsInChildren<Object> ();
//		foreach (Object child in enemyChildren){
//			child.tag = enemyCastle.tag;
//			Debug.Log ("child " + child.name);
//		}

		playerCastle = Instantiate (castles [level]) as GameObject;
		playerCastle.tag = "playerBlock";
		playerCastlePos = enemyCastlePos;
		playerCastlePos.x = -enemyCastlePos.x;
		playerCastle.transform.position = playerCastlePos;

		shotsTaken = 0;
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
		
	public static void ShotsFired(){
		S.shotsTaken++;
	}
}
