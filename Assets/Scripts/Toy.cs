using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
//Alex Goslen, Will Timpson
public class Toy : MonoBehaviour {


	private float speed = 12.4f;
	private Vector3 projPos;
	private int divValue = 1000;
	private float randomWidth;
	private float range = 100f;
	private int changeInScore = 10;
	public int playerScore = 0;
	public int enemyScore = 0;
	// Use this for initialization
	void Start () {
		//creates random arc with for Enemies Toys
		float rw = Random.value * divValue;
		randomWidth = Random.Range(rw - range, rw + range);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.tag.Equals("enemyToy")) {
			float deltaX = -speed * Time.deltaTime;
			projPos.x += deltaX;
			//change y like a parabola, y=x^2/divVale + height
			projPos.y = -((((projPos.x-deltaX) * (projPos.x-deltaX))/randomWidth))+4;
			projPos.z = 0;
			if (this != null) {
				this.transform.position = projPos;
			}
		}
			
	}

	void OnCollisionEnter(Collision col){
		//Updates players score when player hits an enemy block
		if (!(this.tag.Equals ("enemyToy")) &&!col.gameObject.name.Equals ("Enemy") && !col.gameObject.name.Equals ("Toy(Clone)") && !col.gameObject.name.Equals("Ground") && !col.gameObject.name.Equals("SlingShot")) {
			playerScore += changeInScore;
			Debug.Log ("player score " + playerScore);
		}
		//Updates enemy score when player hits an player block
		if (!(this.tag.Equals ("playerToy")) &&!col.gameObject.name.Equals ("Enemy") && !col.gameObject.name.Equals ("Toy(Clone)") && !col.gameObject.name.Equals("Ground") && !col.gameObject.name.Equals("SlingShot")) {
			enemyScore += changeInScore;
			Debug.Log ("enemy score " + enemyScore);
		}
		//Destroys the objects that collided
		if (!col.gameObject.name.Equals ("Enemy") && !col.gameObject.name.Equals ("Toy(Clone)") && !col.gameObject.name.Equals("Ground") && !col.gameObject.name.Equals("SlingShot")) {
			Destroy (col.gameObject);
			Destroy (this.gameObject);

		}
		//Destroys any object that collides with ground
		if (col.gameObject.name.Equals ("Ground")) {
			Destroy (this.gameObject);
		}


	}
		
	//Calculates how many friends are added at the end of each level based on players score
	//enemies score
	public int CalcNewFriends(int pScore, int eScore) {
		int numFriends = (pScore - eScore) / 10;
		if (numFriends > 0) {
			return numFriends;
		} else {
			return 0;
		}
			
	}
}
