using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
	public Dictionary<string, int> scores = new Dictionary <string,int> { { "player", 0 }, { "enemy", 0 } };
	private int[] arcDistance = new int[]{ 250, 500, 500, 500 };
	private int[] range = new int[]{ 200, 200, 100, 100 };
	private float[] seconds = new float[]{ 3f, 3f, 3f, 1f };

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
		enemyCastlePos = new Vector3 (50f, -9.5f, 0);
		enemyCastle.transform.position = enemyCastlePos;

		playerCastle = Instantiate (castles [level]) as GameObject;
		playerCastle.tag = "playerBlock";
		playerCastlePos = enemyCastlePos;
		playerCastlePos.x = -enemyCastlePos.x;
		playerCastle.transform.position = playerCastlePos;


		GameObject enemy = GameObject.Find ("Enemy");
		EnemyAI eai = enemy.GetComponent<EnemyAI> ();
		eai.secondsBetweenShot = seconds [level];
		eai.divValue = arcDistance [level];
		eai.range = range [level];

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

	public void UpdateScore(string name, int scoreChange){
		scores[name] += scoreChange;
		Debug.Log (name + "score" + scores[name]);
	}

	//Calculates how many friends are added at the end of each level based on players score and enemies score
	public int CalcNewFriends(int pScore, int eScore) {
		int numFriends = (pScore - eScore) / 10;
		if (numFriends > 0) {
			return numFriends;
		} else {
			return 0;
		}

	}
}
