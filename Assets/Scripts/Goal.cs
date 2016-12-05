using UnityEngine;
using System.Collections;
//Alex Goslen, Will Timpson, Book
public class Goal : MonoBehaviour {
	static public bool goalMet = false;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "enemyToy" | other.gameObject.tag == "playerToy") {
			Goal.goalMet = true;
			//Calculate score at the end of a level
			GameObject camera = GameObject.Find ("Main Camera");
			MissionDemolition md = camera.GetComponent<MissionDemolition> ();
			//Toy t = other.gameObject.GetComponent<Toy> ();
			int numFriendsToAdd = md.CalcNewFriends (md.scores["player"], md.scores["enemy"]);
			Debug.Log ("Number of Friends to Add " + numFriendsToAdd);
			md.scores ["player"] = 0;
			md.scores ["enemy"] = 0;
			//Call New Friends

			//Destroy all enemy toys from previous level
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemyToy");
			for (int i = 0; i < enemies.Length - 2; i++) {
				Destroy (enemies[i]);
			}
			//Destroy all player toys from previous level
			GameObject[] players = GameObject.FindGameObjectsWithTag ("playerToy");
			foreach (GameObject player in players) {
				Destroy (player);
			}
			//Reinstantiates toy prefabs for slingshot and enemy
			GameObject sling = GameObject.Find ("SlingShot");
			SlingShot ss = sling.GetComponent<SlingShot> ();
			ss.ReStart ();
			GameObject enemy = GameObject.Find ("Enemy");
			EnemyAI e = enemy.GetComponent<EnemyAI> ();
			e.ReStart ();

		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

